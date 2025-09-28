using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); 
        //not sure what scene should go next
        Debug.Log("Play!!");
    }

    public void OpenOptions()
    {
     
        Debug.Log("Opening Options!");
    }
    public void OpenLeaderBoard()
    {

        Debug.Log("Opening LeaderBoard!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game!"); 
    }
}
