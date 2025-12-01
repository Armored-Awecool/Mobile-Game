using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class playableCharacter : MonoBehaviour
{

    bool attacking, physAttacking, returning, skill;
    public SAVEMANAGER SAVE;

    public int attack;

    public int magic;

    public float atkSpeed;

    public int defense;

    public int hp;

    float attackTimer, skillTimer;

    float skillSpeed = 30f;
    float skillLength = 10f;

    string classType;

    GameObject[] enemies;

    GameObject targetEnemy;

    Vector3 returnPosition;

    SpriteRenderer sprite;

    public Slider healthBar; //The health bar object

    public GameObject shotSpawn, bullet;
    
    public Transform head;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
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
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));
        }
        else if(heroName == "Hero2")
        {
            classType = SAVE.SaveFile.Hero2.ClassType;
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));
        }
        else if(heroName == "Hero3")
        {
            classType = SAVE.SaveFile.Hero3.ClassType;
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));
        }
        else if(heroName == "Hero4")
        {
            classType = SAVE.SaveFile.Hero4.ClassType;
            Component newComponent = gameObject.AddComponent(Type.GetType(classType));  
        }
        

        attacking = true;
        attackTimer = Time.time;
        skillTimer = Time.time;

        sprite = GetComponent<SpriteRenderer>();

        ResetSlider();
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
            Debug.Log("Skill Activated");
            skillTimer = Time.time;
        }
        else if(skill == true && Time.time >= skillTimer + skillLength)
        {
            skill = false;
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
        hp -= dam;
        healthBar.value = hp;

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

   

}
