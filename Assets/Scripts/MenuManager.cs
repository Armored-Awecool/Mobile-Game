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
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void contiune()//makes sure your update scene is number 2
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(2);
        //not sure what scene should go next
      
    }
    public void newGame()//makes sure your update scene is number 1
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(1);

        //not sure what scene should go next
       
    }
    
    public void OpenOptions()
    {
     
        optionsPanel.gameObject.SetActive(true);
    }
    public void OpenShop()
    {

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
       
    }

    public void CloseOptions()
    {
        optionsPanel.gameObject.SetActive(false);
    }
}
