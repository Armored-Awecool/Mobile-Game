using UnityEngine;

public class enemy : MonoBehaviour
{

    bool attacking, physAttacking, returning;
    public int attack;

    public int magic;

    public float atkSpeed;

    public int hp;

    float attackTimer;

    GameObject[] players;

    public GameObject shotSpawn, bullet;

     GameObject targetPlayer;

    Vector3 returnPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimer = Time.time;
        attacking = true;
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
                        int ran = Random.Range(0, players.Length - 1);
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

    void takeDamage(int dam)
    {
        hp -= dam;

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
