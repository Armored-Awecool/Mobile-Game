using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//is prefab

public enum HeroSelectionState
{
    SelectingHero1,
    SelectingHero2,
    SelectingHero3,
    SelectingHero4,
    AllFinished
}


public class PlayerSelect : MonoBehaviour
{
    public HeroSelectionState currentState = HeroSelectionState.SelectingHero1;
    bool IsCivilan;
    bool IsBarbarian;
    bool IsThief;
    bool IsWizard;

    public SAVEMANAGER SAVE;

    char sign;

    int extraAttack;
    int extraMagic;
    int extraDefense;
    int extraSpeed;
    [Header("For Arrow")]
    public Image Arrow;
    public float newYPosition = 400f;
    [Header("Confirmation Menu")]
    public GameObject ConfirmMenu;
    [Header("Stat Text")]
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI magicText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;
    [Header("Heros")]
    //Hero1
    [Header("Hero 1")]
    public Image BasePic1;
    public Image CivPic1;
    public Image MagPic1;
    public Image BarPic1;
    public Image ThiefPic1;
    //Hero2
    [Header("Hero 2")]
    public Image BasePic2;
    public Image CivPic2;
    public Image MagPic2;
    public Image BarPic2;
    public Image ThiefPic2;
    //Hero3
    [Header("Hero 3")]
    public Image BasePic3;
    public Image CivPic3;
    public Image MagPic3;
    public Image BarPic3;
    public Image ThiefPic3;
    //Hero4
    [Header("Hero 4")]
    public Image BasePic4;
    public Image CivPic4;
    public Image MagPic4;
    public Image BarPic4;
    public Image ThiefPic4;
    [Header("StatScript")]
    public StatsMenu stats;

    bool isHero1;
    bool isHero2;
    bool isHero3;
    bool isHero4;

    bool AllHerosChoosen;
    [Header("Buttons")]
    public Button SaveButton;
    public Button ContinueButton;

    [Header("AreYouReady")]
    public GameObject Ready1;
    public GameObject Ready2;
    public GameObject Ready3;
    public GameObject Ready4;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject savefile = GameObject.Find("SaveFile");
        SAVE = savefile.GetComponent<SAVEMANAGER>();

        isHero1 = true;
        isHero2 = false;
        isHero3 = false;
        isHero4 = false;
        AllHerosChoosen = false;

        Arrow.enabled = true;

        Vector2 currentAnchoredPosition = Arrow.rectTransform.anchoredPosition;
        Vector2 newAnchoredPosition = new Vector2(currentAnchoredPosition.x, newYPosition);
        Arrow.rectTransform.anchoredPosition = newAnchoredPosition;

        SaveButton.gameObject.SetActive(true);
       
        ContinueButton.gameObject.SetActive(false);

        ConfirmMenu.gameObject.SetActive(false);
        Ready1.gameObject.SetActive(false);
        Ready2.gameObject.SetActive(false);
        Ready3.gameObject.SetActive(false);
        Ready4.gameObject.SetActive(false);

        extraAttack = 0; extraMagic = 0; extraDefense = 0; extraSpeed = 0;
        //Hero1
        BasePic1.enabled = true;
        CivPic1.enabled = false;
        MagPic1.enabled = false;
        BarPic1.enabled = false;
        ThiefPic1.enabled = false;
        //Hero2
        BasePic2.enabled = true;
        CivPic2.enabled = false;
        MagPic2.enabled = false;
        BarPic2.enabled = false;
        ThiefPic2.enabled = false;
        //Hero3
        BasePic3.enabled = true;
        CivPic3.enabled = false;
        MagPic3.enabled = false;
        BarPic3.enabled = false;
        ThiefPic3.enabled = false;
        //Hero4
        BasePic4.enabled = true;
        CivPic4.enabled = false;
        MagPic4.enabled = false;
        BarPic4.enabled = false;
        ThiefPic4.enabled = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

    }

    // Update is called once per frame
    void Update()
    {
        
       
      

        if (isHero1)
        {
            HeroOne();
            valueForExtra();
            SetDifferentColor();
            textForExtraStats();
        }
         if (isHero2)
        {
            HeroTwo();
            valueForExtra();
            SetDifferentColor();
            textForExtraStats();
        }
         if (isHero3)
        {
            HeroThree();
            valueForExtra();
            SetDifferentColor();
            textForExtraStats();
        }
         if (isHero4)
        {
            HeroFour();
            valueForExtra();
            SetDifferentColor();
            textForExtraStats();
        }




    }
   
    public void civilanPressed()
    {
        IsCivilan = true;
        IsBarbarian = false;
        IsThief = false;
        IsWizard = false;
    }
    public void barbarianPressed()
    {
        IsCivilan = false;
        IsBarbarian = true;
        IsThief = false;
        IsWizard = false;
    }
    public void thiefPressed()
    {
        IsCivilan = false;
        IsBarbarian = false;
        IsThief = true;
        IsWizard = false;
    }
    public void wizardPressed()
    {
        IsCivilan = false;
        IsBarbarian = false;
        IsThief = false;
        IsWizard = true;
    }

    public void Save()
    {
        ConfirmMenu.gameObject.SetActive(true);
    }
    public void SaveConfirm()
    {
        stats.attackLevel += extraAttack;
       stats.magicLevel += extraMagic;
       stats.defenseLevel += extraDefense;
       stats.speedLevel += extraSpeed;

        switch (currentState)
        {
            case HeroSelectionState.SelectingHero1:
                Ready1.gameObject.SetActive(true);
                isHero1 = false;
                isHero2 = true;
                isHero3 = false;
                isHero4 = false;
                ConfirmMenu.gameObject.SetActive(false);
                currentState = HeroSelectionState.SelectingHero2; 
                break;

            case HeroSelectionState.SelectingHero2:
                Ready2.gameObject.SetActive(true);
                isHero1 = false;
                isHero2 = false;
                isHero3 = true;
                isHero4 = false;
                ConfirmMenu.gameObject.SetActive(false);
                currentState = HeroSelectionState.SelectingHero3; 
                break;

            case HeroSelectionState.SelectingHero3:
                Ready3.gameObject.SetActive(true);
                isHero1 = false;
                isHero2 = false;
                isHero3 = false;
                isHero4 = true;
                ConfirmMenu.gameObject.SetActive(false);
                currentState = HeroSelectionState.SelectingHero4; 
                break;

            case HeroSelectionState.SelectingHero4:
                Ready4.gameObject.SetActive(true);
                currentState = HeroSelectionState.AllFinished; 
                AllHerosChoosen = true; 
                selectionsOfAllFinished(); 
                                           
                break;

            case HeroSelectionState.AllFinished:
               
                Debug.Log("All heroes already selected.");
                break;
        }

        extraAttack = 0; extraMagic = 0; extraDefense = 0; extraSpeed = 0;
    }
    public void SaveDecline()
    {
        ConfirmMenu.gameObject.SetActive(false);
    }
    public void Continue()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(2);
    }

    private void textForExtraStats()
    {
        //attack
        attackText.text = "Attack: " + sign.ToString() + extraAttack.ToString();

        //magic
        magicText.text = "Magic: " + sign.ToString() + extraMagic.ToString();

        //defense
        defenseText.text = "Defense: " + sign.ToString() + extraDefense.ToString();

        //speed
        speedText.text = "Speed: " + sign.ToString() + extraSpeed.ToString();
    }

    private void valueForExtra()
    {
        if (IsCivilan)
        {
            extraAttack = 1; extraMagic = -1; extraDefense = 0; extraSpeed = 2;
           valueForSign();

          
        }
        else if (IsBarbarian)
        {
            extraAttack = 3; extraMagic = -2; extraDefense = 2; extraSpeed = 0;
            valueForSign();

           
        }
        else if (IsThief)
        {
            extraAttack = 1; extraMagic = 0; extraDefense = -1; extraSpeed = 3;
           valueForSign();

           
        }
        else if (IsWizard)
        {
            extraAttack = 1; extraMagic = 3; extraDefense = -1; extraSpeed = 0;
            valueForSign();

          
        }

    }
      private void valueForSign()
      {
          //attack
          if (extraAttack < 0)
          {
              sign = ' ';
          }
          else if (extraAttack > 0)
          {
              sign = '+';
          }
          else if (extraAttack == 0)
          {
              sign = ' ';
          }
          //magic
          if (extraMagic < 0)
          {
              sign = ' ';
          }
          else if (extraMagic > 0)
          {
              sign = '+';
          }
          else if (extraMagic == 0)
          {
              sign = ' ';
          }
          //defense
          if (extraDefense < 0)
          {
              sign = ' ';
          }
          else if (extraDefense > 0)
          {
              sign = '+';
          }
          else if (extraDefense == 0)
          {
              sign = ' ';
          }
          //speed
          if (extraSpeed < 0)
          {
              sign = ' ';  
          }
          else if (extraSpeed > 0)
          {
              sign = '+';
          }
          else if (extraSpeed == 0)
          {
              sign = ' ';
          }
      }

    private void SetDifferentColor()
    {
        //attack
        if (extraAttack < 0)
        {
            attackText.color = Color.red;
        }
        else if (extraAttack > 0)
        {
            attackText.color = Color.green;
        }
        else if (extraAttack == 0)
        {
            attackText.color = Color.black;
        }
        //magic
        if (extraMagic < 0)
        {
            magicText.color = Color.red;
        }
        else if (extraMagic > 0)
        {
            magicText.color = Color.green;
        }
        else if (extraMagic == 0)
        {
            magicText.color = Color.black;
        }
        //defense
        if (extraDefense < 0)
        {
           defenseText.color = Color.red;
        }
        else if (extraDefense > 0)
        {
            defenseText.color = Color.green;
        }
        else if (extraDefense == 0)
        {
            defenseText.color = Color.black;
        }
        //speed
        if (extraSpeed < 0)
        {
           speedText.color = Color.red;
        }
        else if (extraSpeed > 0)
        {
            speedText.color = Color.green;
        }
        else if (extraSpeed == 0)
        {
            speedText.color = Color.black;
        }
    }


    public void selectionsOfAllFinished()
    {
        Arrow.enabled = false;
        SaveButton.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(true);
        ConfirmMenu.gameObject.SetActive(false);

    }

    public void SetArrowYPosition(float yValue)
    {
        Vector2 currentAnchoredPosition = Arrow.rectTransform.anchoredPosition;
        Arrow.rectTransform.anchoredPosition = new Vector2(currentAnchoredPosition.x, yValue);
    }

    public void HeroOne()
    {
        SetArrowYPosition(400);
       

        if (IsCivilan)
        {
            BasePic1.enabled = false;
            CivPic1.enabled = true;
            MagPic1.enabled = false;
            BarPic1.enabled = false;
            ThiefPic1.enabled = false;

            SAVE.SaveFile.Hero1.ClassType = "None";
            SAVE.SaveGame();
        }
        else if (IsBarbarian)
        {
            BasePic1.enabled = false;
            CivPic1.enabled = false;
            MagPic1.enabled = false;
            BarPic1.enabled = true;
            ThiefPic1.enabled = false;

            SAVE.SaveFile.Hero1.ClassType = "Barbarian";
            SAVE.SaveGame();
        }
        else if (IsThief)
        {
            BasePic1.enabled = false;
            CivPic1.enabled = false;
            MagPic1.enabled = false;
            BarPic1.enabled = false;
            ThiefPic1.enabled = true;

            SAVE.SaveFile.Hero1.ClassType = "Thief";
            SAVE.SaveGame();
        }
        else if (IsWizard)
        {
            BasePic1.enabled = false;
            CivPic1.enabled = false;
            MagPic1.enabled = true;
            BarPic1.enabled = false;
            ThiefPic1.enabled = false;

            SAVE.SaveFile.Hero1.ClassType = "Wizard";
            SAVE.SaveGame();
        }
    }

    public void HeroTwo()
    {
        SetArrowYPosition(100);


        if (IsCivilan)
        {
            BasePic2.enabled = false;
            CivPic2.enabled = true;
            MagPic2.enabled = false;
            BarPic2.enabled = false;
            ThiefPic2.enabled = false;

            SAVE.SaveFile.Hero2.ClassType = "None";
            SAVE.SaveGame();
        }
        else if (IsBarbarian)
        {
            BasePic2.enabled = false;
            CivPic2.enabled = false;
            MagPic2.enabled = false;
            BarPic2.enabled = true;
            ThiefPic2.enabled = false;

            SAVE.SaveFile.Hero2.ClassType = "Barbarian";
            SAVE.SaveGame();
        }
        else if (IsThief)
        {
            BasePic2.enabled = false;
            CivPic2.enabled = false;
            MagPic2.enabled = false;
            BarPic2.enabled = false;
            ThiefPic2.enabled = true;

            SAVE.SaveFile.Hero2.ClassType = "Thief";
            SAVE.SaveGame();
        }
        else if (IsWizard)
        {
            BasePic2.enabled = false;
            CivPic2.enabled = false;
            MagPic2.enabled = true;
            BarPic2.enabled = false;
            ThiefPic2.enabled = false;

            SAVE.SaveFile.Hero2.ClassType = "Wizard";
            SAVE.SaveGame();
        }
    }


    public void HeroThree()
    {
        SetArrowYPosition(-200);


        if (IsCivilan)
        {
            BasePic3.enabled = false;
            CivPic3.enabled = true;
            MagPic3.enabled = false;
            BarPic3.enabled = false;
            ThiefPic3.enabled = false;

            SAVE.SaveFile.Hero3.ClassType = "None";
            SAVE.SaveGame();
        }
        else if (IsBarbarian)
        {
            BasePic3.enabled = false;
            CivPic3.enabled = false;
            MagPic3.enabled = false;
            BarPic3.enabled = true;
            ThiefPic3.enabled = false;

            SAVE.SaveFile.Hero3.ClassType = "Barbarian";
            SAVE.SaveGame();
        }
        else if (IsThief)
        {
            BasePic3.enabled = false;
            CivPic3.enabled = false;
            MagPic3.enabled = false;
            BarPic3.enabled = false;
            ThiefPic3.enabled = true;

            SAVE.SaveFile.Hero3.ClassType = "Thief";
            SAVE.SaveGame();
        }
        else if (IsWizard)
        {
            BasePic3.enabled = false;
            CivPic3.enabled = false;
            MagPic3.enabled = true;
            BarPic3.enabled = false;
            ThiefPic3.enabled = false;

            SAVE.SaveFile.Hero3.ClassType = "Wizard";
            SAVE.SaveGame();
        }
    }


    public void HeroFour()
    {
        SetArrowYPosition(-500);


        if (IsCivilan)
        {
            BasePic4.enabled = false;
            CivPic4.enabled = true;
            MagPic4.enabled = false;
            BarPic4.enabled = false;
            ThiefPic4.enabled = false;

            SAVE.SaveFile.Hero4.ClassType = "None";
            SAVE.SaveGame();
        }
        else if (IsBarbarian)
        {
            BasePic4.enabled = false;
            CivPic4.enabled = false;
            MagPic4.enabled = false;
            BarPic4.enabled = true;
            ThiefPic4.enabled = false;

            SAVE.SaveFile.Hero4.ClassType = "Barbarian";
            SAVE.SaveGame();
        }
        else if (IsThief)
        {
            BasePic4.enabled = false;
            CivPic4.enabled = false;
            MagPic4.enabled = false;
            BarPic4.enabled = false;
            ThiefPic4.enabled = true;

            SAVE.SaveFile.Hero4.ClassType = "Thief";
            SAVE.SaveGame();
        }
        else if (IsWizard)
        {
            BasePic4.enabled = false;
            CivPic4.enabled = false;
            MagPic4.enabled = true;
            BarPic4.enabled = false;
            ThiefPic4.enabled = false;

            SAVE.SaveFile.Hero4.ClassType = "Wizard";
            SAVE.SaveGame();
        }
    }




}
