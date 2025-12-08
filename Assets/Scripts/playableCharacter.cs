using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class playableCharacter : MonoBehaviour
{

    bool attacking, physAttacking, returning, skill;
    public SAVEMANAGER SAVE;

    public int attack;

    public int magic;

    public float atkSpeed;

    public int defense;

    public int hp;

    float attackTimer, skillTimer,clickTimer;

    float clickSpeed = 0.5f;

    float skillSpeed = 30f;
    float skillLength = 10f;

    string classType;

    public bool tap, hold;

    GameObject[] enemies;

    GameObject targetEnemy;

    Vector3 returnPosition;

    SpriteRenderer sprite;

    public Slider healthBar; //The health bar object

    public GameObject shotSpawn, bullet;
    
    public Transform head;

    Animator animator;

    InputAction clickAction;
    Material material;

    int skillTapCount =0;

    public TMP_Text skillText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   Renderer rend = GetComponent<Renderer>();
        material = rend.material;
        tap = true;
        hold = false;

        string heroName =gameObject.name;
        animator = GetComponent<Animator>();
        attack += SAVE.SaveFile.Hero1.Attack;
        magic += SAVE.SaveFile.Hero1.Magic;
        atkSpeed *= SAVE.SaveFile.Hero1.Speed;
        hp += SAVE.SaveFile.Hero1.Health;
        defense += SAVE.SaveFile.Hero1.Defense;
        if(heroName == "Hero1")
        {
            classType = SAVE.SaveFile.Hero1.ClassType;
            Debug.Log(classType);
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));
        }
        else if(heroName == "Hero2")
        {
            classType = SAVE.SaveFile.Hero2.ClassType;
            Debug.Log(classType);
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));
        }
        else if(heroName == "Hero3")
        {
            classType = SAVE.SaveFile.Hero3.ClassType;
            Debug.Log(classType);
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));
        }
        else if(heroName == "Hero4")
        {
            classType = SAVE.SaveFile.Hero4.ClassType;
            Debug.Log(classType);
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));  
        }
        
        if(classType == "None")
        {
            skillSpeed = 9999f;
        }
        attacking = true;
        attackTimer = Time.time;
        skillTimer = Time.time;

        sprite = GetComponent<SpriteRenderer>();

        ResetSlider();
    }

    void OnEnable()
        {
            clickAction.Enable();
            clickAction.performed += OnClickPerformed;
        }

        void Awake()
        {
                clickAction = new InputAction("TouchPress", type: InputActionType.Button);
                clickAction.AddBinding("<Pointer>/press");
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
        if(skill!= true && Time.time >= skillTimer + skillSpeed)
        {
            skill = true;
            skillText.gameObject.SetActive(true);
            Debug.Log("Skill Activated");
            skillTimer = Time.time;
        }
        else if(skill == true && Time.time >= skillTimer + skillLength)
        {
            skill = false;
            skillText.gameObject.SetActive(false);
            Debug.Log("Skill Deactivated");
            skillTimer = Time.time;
        }
        

        if (attacking)
        {
            //search for enemies and attack if there are any
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if(!skill)
            {
            if (enemies.Length > 0)
            {
                if (Time.time >= attackTimer + (5f * atkSpeed))
                {
                    int random = Random.Range(1, 3);
                    if (random == 1)
                    {
                        int ran = Random.Range(0, enemies.Length - 1);
                        targetEnemy = enemies[ran];
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
                //attacking = false;

            }
            }
            else
            {
                   if (Time.time >= attackTimer + (5f * atkSpeed))
                {
                    if(classType == "Barbarian")
                    {
                        int ran = Random.Range(0, enemies.Length - 1);
                        targetEnemy = enemies[ran];
                        returnPosition = gameObject.transform.position;


                        physAttacking = true;
                        attacking = false;
                    }
                    else if(classType == "Wizard")
                    {
                        magicAttack();
                    }
                    else if(classType == "Thief")
                    {
                        foreach(GameObject enemy in enemies)
                        {
                            enemy.SendMessage("takeDamage", attack/enemies.Length);
                            attackTimer = Time.time;
                        }
                     }

                }
            }
        }
        else if (physAttacking == true)
        {
            if (targetEnemy != null)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetEnemy.transform.position, 20 * Time.deltaTime);

                if (Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position) < 1)
                {
                    physicalAttack(targetEnemy);
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

    void physicalAttack(GameObject enemy)
    {
        
        /*Debug.Log(attack);

        if (enemies.Length == 1)
        {
            enemies[0].SendMessage("takeDamage", attack);
        }
        else
        {
            int random = Random.Range(0, enemies.Length - 1);
            
            enemies[random].SendMessage("takeDamage", attack);
        }*/
        animator.SetTrigger("Attacking");
        enemy.SendMessage("takeDamage", attack);
        Debug.Log(targetEnemy);



    }

    void magicAttack()
    {


        /*if (enemies.Length == 1)
        {
            enemies[0].SendMessage("takeDamage", magic);
        }
        else
        {
            int random = Random.Range(0, enemies.Length - 1);
            
            enemies[random].SendMessage("takeDamage", magic);
        }

        attackTimer = Time.time;*/

        if (gameObject != null)
        {
            animator.SetTrigger("Attacking");
            GameObject newBullet = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation);
            newBullet.SendMessage("setDamage", magic);
        }

        attackTimer = Time.time;

    }   



    void takeDamage(int dam)
    {
        animator.SetTrigger("Hurt");
        hp -= dam/(defense/2);
        healthBar.value = hp;
        AudioManager.Instance.PlayDamage();

        if (hp <= 0)
        {
            //sprite.color = Color.red;
            //attacking = false;
            Destroy(this.gameObject);
        }
        Debug.Log("Player took:" + dam + " damage");
    }

    void classAttack(int atk)
    {
        attack += atk;
    }

    void classMagic(int mag)
    {
        magic += mag;
    }

    void classAttackSpeed(float atkspd)
    {
        atkSpeed *= atkspd;
    }

    void classHealth(int health)
    {
        hp += health;
    }

    void setClass(string classs)
    {
        classType = classs;
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
                    clickSkill();
                }
            }
        }
        }

        public void clickSkill()
    {
        if (Time.time >= clickTimer + clickSpeed)
                    {
                        Debug.Log("Target GameObject " + gameObject.name + " was clicked/touched!");
                        if(!skill)
                    {
                        skillTapCount++;
                        if(skillTapCount >=5)
                    {
                        skill = true;
                            skillText.gameObject.SetActive(true);
                        Debug.Log("Skill Activated");
                        skillTimer = Time.time;
                        skillTapCount =0;
                    }
                }
                }
    }


   

}
