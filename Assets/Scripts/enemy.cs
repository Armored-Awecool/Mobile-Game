using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class enemy : MonoBehaviour
{

    bool attacking, physAttacking, returning;

    public int level;
    public SAVEMANAGER Save;
    public double money;
    public int attack;

    public int magic;

    public float atkSpeed, clickSpeed = 0.5f;

    public int hp;

    float attackTimer, clickTimer;

    GameObject[] players;

    public GameObject shotSpawn, bullet;

     GameObject targetPlayer;

    Vector3 returnPosition;

    public Slider healthBar; //The health bar object

    bool gameOver;

    public InputAction clickAction;

    int skillTapCount =0;

    public bool tap, hold;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   

        tap= GameObject.FindWithTag("Player").GetComponent<playableCharacter>().tap;
        hold= GameObject.FindWithTag("Player").GetComponent<playableCharacter>().hold;
        attackTimer = Time.time;
        attacking = true;
        attack = (int)(attack * level);
        magic = (int)(magic * level);
        hp = (int)(hp * (level*1.5f));
        money = (int)(money * (level*1.5f));
        atkSpeed /= (1 + (level * 0.1f));

        GameObject savefile = GameObject.Find("SaveFile");
        Save = savefile.GetComponent<SAVEMANAGER>();

        ResetSlider();
    }

    void Awake()
    {
        clickAction = new InputAction("TouchPress", type: InputActionType.Button);
        clickAction.AddBinding("<Pointer>/press");
    }

    void OnEnable()
        {
            clickAction.Enable();
            clickAction.performed += OnClickPerformed;
        }

        void OnDisable()
        {
            clickAction.performed -= OnClickPerformed;
            clickAction.Disable();
        }

    public void ResetSlider() //Resets the health bar
    {
        healthBar.maxValue = hp;
        healthBar.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
        if (attacking)
        {
            //search for players and attack if there are any
            players = GameObject.FindGameObjectsWithTag("Player");


            if (players.Length > 0)
            {
                if (Time.time >= attackTimer + (5f * atkSpeed))
                {
                    int random = Random.Range(1, 3);
                    if (random == 1)
                    {
                        int ran = Random.Range(0, players.Length);
                        targetPlayer = players[ran];
                        returnPosition = gameObject.transform.position;


                        physAttacking = true;
                        attacking = false;
                    }
                    else
                    {
                        magicAttack();
                    }
                }

            }
            else
            {
                AudioManager.Instance.PlayGameOver();
                gameOver = true;
                attacking = false;
            }

        }
        else if (physAttacking == true)
        {
            if (targetPlayer != null)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPlayer.transform.position, 20 * Time.deltaTime);

                if (Vector3.Distance(gameObject.transform.position, targetPlayer.transform.position) < 1)
                {
                    physicalAttack(targetPlayer);
                    physAttacking = false;
                    returning = true;
                }
            }
            else
            {
                returning = true;
                physAttacking = false;
            }
            }
        else if (returning == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, returnPosition, 20 * Time.deltaTime);

            if (gameObject.transform.position == returnPosition)
            {
                returning = false;
                attacking = true;
                attackTimer = Time.time;
            }
        }
        }
        else
        {
                Save.SaveGame();
                Invoke("ReturnToMenu", 2);
        }
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(2);
    }

    void physicalAttack(GameObject player)
    {
        /*Debug.Log(attack);

        if (players.Length == 1)
        {
            players[0].SendMessage("takeDamage", attack);
        }
        else
        {
            int random = Random.Range(0, players.Length - 1);
            
            players[random].SendMessage("takeDamage", attack);
        }*/

        player.SendMessage("takeDamage", attack);
        Debug.Log(targetPlayer);



    }

    void magicAttack()
    {
        Debug.Log(magic);

        if (gameObject != null)
        {
            GameObject newBullet = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation);
            newBullet.SendMessage("setDamage", magic);
        }

        attackTimer = Time.time;
    }

    public void takeDamage(int dam)
    {
        hp -= dam;
        healthBar.value = hp;
        AudioManager.Instance.PlayDamage();

        if (hp <= 0)
        {
            Save.SaveFile.Money += money;
            Destroy(this.gameObject);
        }
    }

    public void setLevel(int lvl)
    {
        level = lvl;
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
        {
            if(tap){
            Vector2 screenPosition = Mouse.current.position.ReadValue(); 
            Vector2 screenPositionMobile = Touchscreen.current.primaryTouch.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            Ray raymobile = Camera.main.ScreenPointToRay(screenPositionMobile);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) || Physics.Raycast(raymobile, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (Time.time >= clickTimer + clickSpeed)
                    {
                        Debug.Log("Target GameObject " + gameObject.name + " was clicked/touched!");
                        takeDamage((int)healthBar.maxValue / 10); //Deals 10% of enemy health as damage
                        clickTimer = Time.time;
                }
            }
            }
        }
        }
}
