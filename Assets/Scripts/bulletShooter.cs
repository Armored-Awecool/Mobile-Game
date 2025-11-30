using UnityEngine;

public class bulletShooter : MonoBehaviour
{
    int dam;
    GameObject[] enemies;

    GameObject targetEnemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.tag == "playerBullet")
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        else if (gameObject.tag == "enemyBullet")
        {
            enemies = GameObject.FindGameObjectsWithTag("Player");
        }

        int ran = Random.Range(0, enemies.Length);
        targetEnemy = enemies[ran];
    }

    // Update is called once per frame
    void Update()
    {
            if (targetEnemy != null)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetEnemy.transform.position, 10 * Time.deltaTime);

                if (Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position) < .05f)
            {
                    if(dam>0)
                    {
                     targetEnemy.SendMessage("takeDamage", dam);
                    }
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
    }


    void setDamage(int damage)
    {
        dam = damage;
    }
}
