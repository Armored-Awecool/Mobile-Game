using UnityEngine;

public class tipVanish : MonoBehaviour
{
    float offTimer;
    void OnEnable()
    {
        offTimer = Time.time;
    }
    void Update()
    {
        if(Time.time >= offTimer + 5f)
        {
            gameObject.SetActive(false);
        }
    }
}
