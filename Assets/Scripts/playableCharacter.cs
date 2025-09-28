using UnityEngine;

public class playableCharacter : MonoBehaviour
{

    bool attacking;


    public int attack;

    public int magic;

    public float atkSpeed;

    public int hp;

    float attackTimer;

    GameObject[] enemies;

    SpriteRenderer sprite;
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
                        physicalAttack();
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
            }

        }
    }

    void physicalAttack()
    {
        Debug.Log(attack);

        if (enemies.Length == 1)
        {
            enemies[0].SendMessage("takeDamage", attack);
        }
        else
        {
            int random = Random.Range(0, enemies.Length - 1);
            
            enemies[random].SendMessage("takeDamage", attack);
        }



        attackTimer = Time.time;
    }

    void magicAttack()
    {
        Debug.Log(magic);


        if (enemies.Length == 1)
        {
            enemies[0].SendMessage("takeDamage", magic);
        }
        else
        {
            int random = Random.Range(0, enemies.Length - 1);
            
            enemies[random].SendMessage("takeDamage", magic);
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
