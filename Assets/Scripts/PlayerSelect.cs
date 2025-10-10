using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSelect : MonoBehaviour
{
    bool IsCivilan;
    bool IsBarbarian;
    bool IsThief;
    bool IsWizard;

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
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        extraAttack = 0; extraMagic = 0; extraDefense = 0; extraSpeed = 0;
        sign = ' ';

        //attack
        attackText.text = "Attack: " + sign.ToString() + extraAttack.ToString();

        //magic
        magicText.text = "Magic: " + sign.ToString() + extraMagic.ToString();

        //defense
        defenseText.text = "Defense: " + sign.ToString() + extraDefense.ToString();

        //speed
        speedText.text = "Speed: " + sign.ToString() + extraSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        valueForExtra();
        valueForSign();
        SetDifferentColor();

       
       
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

    private void valueForExtra()
    {
        if (IsCivilan)
        {
            extraAttack = 1; extraMagic = -1; extraDefense = 0; extraSpeed = 2;

        }
        if (IsBarbarian)
        {
            extraAttack = 3; extraMagic = -2; extraDefense = 2; extraSpeed = 0;
        }
        if (IsThief)
        {
            extraAttack = 1; extraMagic = 0; extraDefense = -1; extraSpeed = 3;
        }
        if (IsWizard)
        {
            extraAttack = 1; extraMagic = 3; extraDefense = -1; extraSpeed = 0;
        }

    }
    private void valueForSign()
    {
        //attack
        if (extraAttack < 0)
        {
            sign = '-';
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
            sign = '-';
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
            sign = '-';
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
            sign = '-';
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
