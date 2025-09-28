using UnityEngine;

public class enemy : MonoBehaviour
{

    bool attacking;
    public int attack;

    public int magic;

    public float atkSpeed;

    public int hp;

    float attackTimer;

    GameObject[] players;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
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
            }

        }

    }

    void physicalAttack()
    {
        Debug.Log(attack);

        if (players.Length == 1)
        {
            players[0].SendMessage("takeDamage", attack);
        }
        else
        {
            int random = Random.Range(0, players.Length - 1);

            players[random].SendMessage("takeDamage", attack);
        }



        attackTimer = Time.time;
    }

    void magicAttack()
    {
        Debug.Log(magic);


        if (players.Length == 1)
        {
            players[0].SendMessage("takeDamage", magic);
        }
        else
        {
            int random = Random.Range(0, players.Length - 1);

            players[random].SendMessage("takeDamage", magic);
        }

        attackTimer = Time.time;
    }

    void takeDamage(int dam)
    {
        hp -= dam;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
