using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    public AudioSource source;
    public AudioClip select;
    public AudioClip damage;
    public AudioClip gameOver;

    void Awake()
    {
        Instance = this;
    }

    public void PlaySelect()
    {
        source.clip = select;
        source.Play();
    }

    public void PlayDamage()
    {
        source.clip = damage;
        source.Play();
    }

    public void PlayGameOver()
    {
        source.clip = gameOver;
        source.Play();
    }
}
