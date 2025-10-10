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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        extraAttack = 0; extraMagic = 0; extraDefense = 0; extraSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Name.isFocused)
        {
            Debug.Log("Input Field is working");
        }

        valueForExtra();
        valueForSign();


       
       
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
            extraAttack = 3; extraMagic = -1; extraDefense = 2; extraSpeed = 0;
        }
        if (IsThief)
        {
            extraAttack = 1; extraMagic = -1; extraDefense = 0; extraSpeed = 3;
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





    private void OnGUI()
    {
       
        
        //attack
        if(extraAttack < 0)
        { 
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(-301, 207, 200, 50), "Attack: " + sign + extraAttack);
        }
        else if (extraAttack > 0)
        {
            GUI.contentColor = Color.green;
            GUI.Label(new Rect(-301, 207, 200, 50), "Attack: " + sign + extraAttack);
        }
        else 
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(-301, 207, 200, 50), "Attack: " + sign + extraAttack);
        }
        //magic
        if (extraMagic < 0)
        {
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(-301, 86, 200, 50), "Magic: " + sign + extraMagic);
        }
        else if (extraMagic > 0)
        {
            GUI.contentColor = Color.green;
            GUI.Label(new Rect(-301, 86, 200, 50), "Magic: " + sign + extraMagic);
        }
        else 
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(-301, 86, 200, 50), "Magic: " + sign + extraMagic);
        }
        //defense
        if (extraDefense < 0)
        {
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(-301, -35, 200, 50), "Defense: " + sign + extraDefense);
        }
        else if (extraDefense > 0)
        {
            GUI.contentColor = Color.green;
            GUI.Label(new Rect(-301, -35, 200, 50), "Defense: " + sign + extraDefense);
        }
        else 
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(-301, -35, 200, 50), "Defense: " + sign + extraDefense);
        }
        //speed
        if (extraSpeed < 0)
        {
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(-301, -139, 200, 50), "Speed: " + sign + extraSpeed);
        }
        else if (extraSpeed > 0)
        {
            GUI.contentColor = Color.green;
            GUI.Label(new Rect(-301, -139, 200, 50), "Speed: " + sign + extraSpeed);
        }
        else 
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(-301, -139, 200, 50), "Speed: " + sign + extraSpeed);
        }


       
       
        

    }
}
