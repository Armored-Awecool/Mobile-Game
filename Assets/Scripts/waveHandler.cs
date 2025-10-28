using Unity.Mathematics;
using UnityEngine;

public class waveHandler : MonoBehaviour
{
    public GameObject[] waves = new GameObject[6];
    Vector3 position = new Vector3(3193.04f, 644.28f, -20.55815f);
    int waveNum;
    void Start()
    {
        waveNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            waveNum++;
            GameObject nextWave = waves[UnityEngine.Random.Range(0, waves.Length)];
            Instantiate(nextWave, position, quaternion.identity);
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.SendMessage("setLevel", waveNum);
            }
        }
    }
}
