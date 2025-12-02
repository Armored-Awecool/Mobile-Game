using UnityEngine;
using TMPro;

public class dungeonButtonHandler : MonoBehaviour
{
    public SAVEMANAGER SAVE;
    public GameObject fastForwardButton;
    public GameObject playButton;
    public int potionCount,atkHelmetCount,dfHelmetCount;

    public TMP_Text potionText,atkHelmetText,dfHelmetText;

    GameObject hero1, hero2, hero3, hero4;
    bool speedChanged;

    float buttonTimer;
    float buttonDelay = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonTimer = Time.time;
        speedChanged = false;
        potionCount = SAVE.SaveFile.PotionCount;
        atkHelmetCount = SAVE.SaveFile.atkHelmetCount;
        dfHelmetCount = SAVE.SaveFile.defHelmetCount;

        potionText.text = "x" + potionCount;
        atkHelmetText.text = "x" + atkHelmetCount;
        dfHelmetText.text = "x" + dfHelmetCount;

        hero1 = GameObject.Find("Hero1");
        hero2 = GameObject.Find("Hero2");
        hero3 = GameObject.Find("Hero3");
        hero4 = GameObject.Find("Hero4");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0f)
        {
            fastForwardButton.SetActive(true);
            playButton.SetActive(false);
        }
    }

    public void changeSpeed()
    {
        if(Time.time >= buttonTimer + buttonDelay)
        {
            buttonTimer = Time.time;
        }
        else
        {
            return;
        }
        Debug.Log("Changing Speed");
        if(Time.timeScale != 0f)
        {
            Debug.Log("Speed Change Allowed");
        if(!speedChanged)
        {
            Debug.Log("Speeding up");
            Time.timeScale = 2f;
            fastForwardButton.SetActive(false);
            playButton.SetActive(true);
            speedChanged = true;
            return;
        }
        else
        {
            Debug.Log("Slowing down");
            Time.timeScale = 1f;
            fastForwardButton.SetActive(true);
            playButton.SetActive(false);
            speedChanged = false;
            return;
        }
        }
    }

    public void usePotion()
    {
        if(Time.time >= buttonTimer + buttonDelay)
        {
            buttonTimer = Time.time;
        }
        else
        {
            return;
        }  
        if(potionCount > 0)
        {
            potionCount--;
            SAVE.SaveFile.PotionCount = potionCount;
            potionText.text = "x" + potionCount;

            if(hero1!= null)
            hero1.GetComponent<playableCharacter>().atkSpeed /= 2;
            if(hero2!= null)
            hero2.GetComponent<playableCharacter>().atkSpeed /= 2;
            if(hero3!= null)
            hero3.GetComponent<playableCharacter>().atkSpeed /= 2;
            if(hero4!= null)
            hero4.GetComponent<playableCharacter>().atkSpeed /= 2;
        }
    }

    public void useAtkHelmet()
    {
        if(Time.time >= buttonTimer + buttonDelay)
        {
            buttonTimer = Time.time;
        }
        else
        {
            return;
        }
        if(atkHelmetCount > 0)
        {
            atkHelmetCount--;
            SAVE.SaveFile.atkHelmetCount = atkHelmetCount;
            atkHelmetText.text = "x" + atkHelmetCount;
            if(hero1!= null)
            hero1.GetComponent<playableCharacter>().attack *= 2;
            if(hero2!= null)
            hero2.GetComponent<playableCharacter>().attack *= 2;
            if(hero3!= null)
            hero3.GetComponent<playableCharacter>().attack *= 2;
            if(hero4!= null)
            hero4.GetComponent<playableCharacter>().attack *= 2;

            if(hero1!= null)
            hero1.GetComponent<playableCharacter>().magic *= 2;
            if(hero2!= null)
            hero2.GetComponent<playableCharacter>().magic *= 2;
            if(hero3!= null)
            hero3.GetComponent<playableCharacter>().magic *= 2;
            if(hero4!= null)
            hero4.GetComponent<playableCharacter>().magic *= 2;
        }
    }

    public void useDefHelmet()
    {if(Time.time >= buttonTimer + buttonDelay)
        {
            buttonTimer = Time.time;
        }
        else
        {
            return;
        } 
        if(dfHelmetCount > 0)
        {
            dfHelmetCount--;
            SAVE.SaveFile.defHelmetCount = dfHelmetCount;
            dfHelmetText.text = "x" + dfHelmetCount;

            if(hero1!= null)
            hero1.GetComponent<playableCharacter>().defense *= 2;
            if(hero2!= null)
            hero2.GetComponent<playableCharacter>().defense *= 2;
            if(hero3!= null)
            hero3.GetComponent<playableCharacter>().defense *= 2;
            if(hero4!= null)
            hero4.GetComponent<playableCharacter>().defense *= 2;
        }
    }
}
