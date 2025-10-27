using UnityEngine;
using UnityEngine.SceneManagement;

public class playableCharacter : MonoBehaviour
{

    bool attacking, physAttacking, returning;


    public int attack;

    public int magic;

    public float atkSpeed;

    public int hp;

    float attackTimer;

    GameObject[] enemies;

    GameObject targetEnemy;

    Vector3 returnPosition;

    SpriteRenderer sprite;

    public GameObject shotSpawn, bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        attacking = true;
        attackTimer = Time.time;

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            //search for enemies and attack if there are any
            enemies = GameObject.FindGameObjectsWithTag("Enemy");


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
                attacking = false;
                sprite.color = Color.blue;
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                SceneManager.LoadScene(2);//just make sure it is the updates scene

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

        enemy.SendMessage("takeDamage", attack);
        Debug.Log(targetEnemy);



    }

    void magicAttack()
    {
        Debug.Log(magic);


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
            GameObject newBullet = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation);
            newBullet.SendMessage("setDamage", magic);
        }

        attackTimer = Time.time;

    }   



    void takeDamage(int dam)
    {
        hp -= dam;

        if (hp <= 0)
        {
            sprite.color = Color.red;
            attacking = false;
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

}
