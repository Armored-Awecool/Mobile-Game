using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    /*   public void PlayGame()
       {
           Screen.orientation = ScreenOrientation.LandscapeLeft;
           SceneManager.LoadScene(1); 
           //not sure what scene should go next
           Debug.Log("Play!!");
       }*/
    private void Start()
    {
        optionsPanel.gameObject.SetActive(false);
    }
    public void contiune()//makes sure your update scene is number 2
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(2);
        //not sure what scene should go next
        Debug.Log("Play!!");
    }
    public void newGame()//makes sure your update scene is number 1
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(1);
        //not sure what scene should go next
        Debug.Log("Play!!");
    }
    public void OpenOptions()
    {
     
        optionsPanel.gameObject.SetActive(true);
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

    public void CloseOptions()
    {
        optionsPanel.gameObject.SetActive(false);
    }
}
