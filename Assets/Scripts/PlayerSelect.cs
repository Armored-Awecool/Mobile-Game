using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//is prefab


public class PlayerSelect : MonoBehaviour
{
  public  bool IsCivilan;
  public  bool IsBarbarian;
   public bool IsThief;
   public bool IsWizard;

    char sign;

    int extraAttack;
    int extraMagic;
    int extraDefense;
    int extraSpeed;

    public TMP_InputField Name;

    public TextMeshProUGUI attackText;
    public TextMeshProUGUI magicText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;

    public Image CivPic;
    public Image MagPic;
    public Image BarPic;
    public Image ThiefPic;
    public Image BasePic;

    public StatsMenu stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        extraAttack = 0; extraMagic = 0; extraDefense = 0; extraSpeed = 0;
        BasePic.enabled = true;
        CivPic.enabled = false;
        MagPic.enabled = false;
        BarPic.enabled = false;
        ThiefPic.enabled = false;
        Screen.orientation = ScreenOrientation.LandscapeLeft;

    }

    // Update is called once per frame
    void Update()
    {
        
       
        valueForExtra();
        SetDifferentColor();
        textForExtraStats();

        stats.attackLevel += extraAttack;
        stats.magicLevel += extraMagic;
        stats.defenseLevel += extraDefense;
        stats.speedLevel += extraSpeed;
       
       
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

    public void Next()
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

            BasePic.enabled = false;
            CivPic.enabled = true;
            MagPic.enabled = false;
            BarPic.enabled = false;
            ThiefPic.enabled = false;

        }
        else if (IsBarbarian)
        {
            extraAttack = 3; extraMagic = -2; extraDefense = 2; extraSpeed = 0;
            valueForSign();

            BasePic.enabled = false;
            CivPic.enabled = false;
            MagPic.enabled = false;
            BarPic.enabled = true;
            ThiefPic.enabled = false;
        }
        else if (IsThief)
        {
            extraAttack = 1; extraMagic = 0; extraDefense = -1; extraSpeed = 3;
           valueForSign();

            BasePic.enabled = false;
            CivPic.enabled = false;
            MagPic.enabled = false;
            BarPic.enabled = false;
            ThiefPic.enabled = true;
        }
        else if (IsWizard)
        {
            extraAttack = 1; extraMagic = 3; extraDefense = -1; extraSpeed = 0;
            valueForSign();

            BasePic.enabled = false;
            CivPic.enabled = false;
            MagPic.enabled = true;
            BarPic.enabled = false;
            ThiefPic.enabled = false;
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





}
