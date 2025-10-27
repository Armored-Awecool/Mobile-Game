using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this as the instance
            instance = this;
            // Prevent the game object from being destroyed when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this new one to prevent duplicates
            Destroy(gameObject);
        }
    }
}
