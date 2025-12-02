using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    float oldTime;
    public static bool GameIsPaused = false; 

    public GameObject pauseMenuUI;

   
    public void PauseButton()
    {
  pauseMenuUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true; 
    }

    public void LoadMenu()
    {
        Time.timeScale = oldTime;
        SceneManager.LoadScene(0); 
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void Close()
    {
        pauseMenuUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
