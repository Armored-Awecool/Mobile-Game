using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class waveHandler : MonoBehaviour
{
    public GameObject[] waves = new GameObject[6];
    public TMP_Text waveText;
    Vector3 position = new Vector3(3193.04f, 644.28f, -20.55815f);
    int waveNum;
    void Start()
    {
        waveNum = 1;
        waveText.text = "Wave: " + waveNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            waveNum++;
            waveText.text = "Wave: " + waveNum;
            GameObject nextWave = waves[UnityEngine.Random.Range(0, waves.Length)];
            Instantiate(nextWave, position, quaternion.identity);
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.SendMessage("setLevel", waveNum);
            }
        }
    }
}
