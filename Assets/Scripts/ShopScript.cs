using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public TextMeshProUGUI totalMoney;
    public TextMeshProUGUI totalJewel;
    public SAVEMANAGER SAVE;
    public StatsMenu statsMenu;
    public double TotalMoneyCount
    {
        get => SAVE.SaveFile.Money;
        set => SAVE.SaveFile.Money = value;

    }
    public double TotalJewelCount
    {
        get => SAVE.SaveFile.Jewel;
        set => SAVE.SaveFile.Jewel = value;

    }

    //panels
    public GameObject mainPage;
    public GameObject hatPage;
    public GameObject potionPage;
    public GameObject jewelPage;
    public GameObject foodPage;

    //COST
    public TextMeshProUGUI defHatPrice;
    public int defHatAmount = 50;

    public TextMeshProUGUI atkHatPrice;
    public int atkHatAmount = 100;

    public TextMeshProUGUI potionPrice;
    public int potionAmount = 200;

    public TextMeshProUGUI firstJewelPrice;
    public int firstJewelAmount = 1;

    public TextMeshProUGUI secondJewelPrice;
    public int secondJewelAmount = 5;

    public TextMeshProUGUI thirdJewelPrice;
    public int thirdJewelAmount = 10;

    public TextMeshProUGUI defFoodPrice;
    public int defFoodAmount = 200;

    public TextMeshProUGUI magFoodPrice;
    public int magFoodAmount = 300;

    public TextMeshProUGUI atkFoodPrice;
    public int atkFoodAmount = 400;

    public TextMeshProUGUI speedFoodPrice;
    public int speedFoodAmount = 300;





    //tip

    public GameObject tooltipPanel; // Assign your UI panel for the tooltip
    public TextMeshProUGUI tooltipText; // Assign your TextMeshProUGUI component
    public float displayDuration = 3f; // Duration in seconds
    string FeedbackText;
    private bool needToStop;

    //duration in minutes
    public float displayDurationforPotion = 5f; // Duration in minutes
    public float displayDurationforHats = 2f; // Duration in minutes

    //buttons for disable
    public Button DefHat;
    public TextMeshProUGUI defText;
    public Button AtkHat;
    public TextMeshProUGUI atkText;
    public Button Potion;
    public TextMeshProUGUI potionText;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defHatAmount = 50;
        atkHatAmount = 100;
 
        potionAmount = 200;

        firstJewelAmount = 1;
        secondJewelAmount = 5;
        thirdJewelAmount = 10;

        defFoodAmount = 200;
        magFoodAmount = 300;    
        atkFoodAmount = 400;
        speedFoodAmount = 300;

        tooltipPanel.gameObject.SetActive(false);
        FeedbackText = "insufficient Funds\r\naka(You broke lil homie!)";
        needToStop = false;

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CancelButton()
    {
        mainPage.gameObject.SetActive(true);
        hatPage.gameObject.SetActive(false);
        potionPage.gameObject.SetActive(false);
        jewelPage.gameObject.SetActive(false);
        foodPage.gameObject.SetActive(false);
    }
    public void HatButton()
    {
        mainPage.gameObject.SetActive(false);
        hatPage.gameObject.SetActive(true);
        potionPage.gameObject.SetActive(false);
        jewelPage.gameObject.SetActive(false);
        foodPage.gameObject.SetActive(false);
    }
    public void PotionButton()
    {
        mainPage.gameObject.SetActive(false);
        hatPage.gameObject.SetActive(false);
        potionPage.gameObject.SetActive(true);
        jewelPage.gameObject.SetActive(false);
        foodPage.gameObject.SetActive(false);
    }
    public void JewelButton()
    {
        mainPage.gameObject.SetActive(false);
        hatPage.gameObject.SetActive(false);
        potionPage.gameObject.SetActive(false);
        jewelPage.gameObject.SetActive(true);
        foodPage.gameObject.SetActive(false);
    }
    public void FoodButton()
    {
        mainPage.gameObject.SetActive(false);
        hatPage.gameObject.SetActive(false);
        potionPage.gameObject.SetActive(false);
        jewelPage.gameObject.SetActive(false);
        foodPage.gameObject.SetActive(true);
    }

    void UpdateUI()
    {
        defHatPrice.text = defHatAmount + " Jewels";
        atkHatPrice.text = atkHatAmount + " Jewels";

        potionPrice.text = potionAmount + " Jewels";

        firstJewelPrice.text = firstJewelAmount + " USD";
        secondJewelPrice.text = secondJewelAmount + " USD";
        thirdJewelPrice.text = thirdJewelAmount + " USD";

        atkFoodPrice.text = atkFoodAmount + " Jewels";
        defFoodPrice.text = defFoodAmount + " Jewels";
        magFoodPrice.text = magFoodAmount + " Jewels";
        speedFoodPrice.text = speedFoodAmount + " Jewels";

        totalMoney.text = "GoldAmount: " + FormatNumber(TotalMoneyCount);
        totalJewel.text = "JewelAmount: " + FormatNumber(TotalJewelCount);
       
    }

    public void buyDefHat()
    {
        if (TotalJewelCount >= defHatAmount)
        {

            TotalJewelCount -= defHatAmount;
            SAVE.SaveFile.Jewel-=defHatAmount;
            UpdateUI();
            SAVE.SaveFile.defHelmetCount+=1;
            SAVE.SaveGame();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void buyAtkHat()
    {
        if (TotalJewelCount >= atkHatAmount)
        {

            TotalJewelCount -= atkHatAmount;
            SAVE.SaveFile.Jewel-=atkHatAmount;
            UpdateUI();
            SAVE.SaveFile.atkHelmetCount+=1;
            SAVE.SaveGame();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void buyPotion()
    {
        if (TotalJewelCount >= potionAmount)
        {

            TotalJewelCount -= potionAmount;
            SAVE.SaveFile.Jewel-=potionAmount;
            UpdateUI();
           SAVE.SaveFile.PotionCount+=1;
            SAVE.SaveGame();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void buyfirstJewel()
    {
    
            TotalJewelCount += 500;
            SAVE.SaveFile.Jewel+=500;
            SAVE.SaveGame();
            UpdateUI();
        
    }
    public void buysecondJewel()
    {
        
            TotalJewelCount += 1200;
            SAVE.SaveFile.Jewel+=1200;
            SAVE.SaveGame();
            UpdateUI();
       
    }
    public void buythirdJewel()
    {
            TotalJewelCount += 2500;
            SAVE.SaveFile.Jewel+=2500;
            SAVE.SaveGame();
            UpdateUI();

    }
    public void buyDefFood()
    {
        if (TotalJewelCount >= defFoodAmount)
        {
            
            TotalJewelCount -= defFoodAmount;
            SAVE.SaveFile.Jewel-=defFoodAmount;
            UpdateUI();
            SAVE.SaveFile.Hero1.Defense+=2;
            SAVE.SaveGame();}
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void buyAtkFood()
    {
        if (TotalJewelCount >= atkFoodAmount)
        {

            TotalJewelCount -= atkFoodAmount;
            SAVE.SaveFile.Jewel-=atkFoodAmount;
            UpdateUI();
           SAVE.SaveFile.Hero1.Attack+=2;
            SAVE.SaveGame();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void buymagFood()
    {
        if (TotalJewelCount >= magFoodAmount)
        {

            TotalJewelCount -= magFoodAmount;
            SAVE.SaveFile.Jewel-=magFoodAmount;
            UpdateUI();
            SAVE.SaveFile.Hero1.Magic+=2;
            SAVE.SaveGame();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void buyspeedFood()
    {
        if (TotalJewelCount >= speedFoodAmount)
        {

            TotalJewelCount -= speedFoodAmount;
            SAVE.SaveFile.Jewel-=speedFoodAmount;
            UpdateUI();
            SAVE.SaveFile.Hero1.Speed/=1.2f;
            SAVE.SaveGame();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }


    public void GoMain()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(0);
    }
    public void GoUpgrade()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(2);
    }

    public void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipPanel.gameObject.SetActive(true);
        StartCoroutine(HideTooltipAfterDelay());
    }

    IEnumerator HideTooltipAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        tooltipPanel.gameObject.SetActive(false);
    }

    IEnumerator HatTimerDef()
    {
        float displayDurationforHatsSeconds = displayDurationforHats * 60f;
        statsMenu.defenseLevel += 20;
        defText.text = "Sold Out";
        DefHat.interactable = false;
        yield return new WaitForSeconds(displayDurationforHatsSeconds);
        statsMenu.defenseLevel -= 20;
        defText.text = "Buy";
        DefHat.interactable = true;

    }
    IEnumerator HatTimerAtk()
    {
        float displayDurationforHatsSeconds = displayDurationforHats * 60f;
        statsMenu.attackLevel += 20;
        atkText.text = "Sold Out";
        AtkHat.interactable = false;
        yield return new WaitForSeconds(displayDurationforHatsSeconds);
        statsMenu.attackLevel -= 20;
        atkText.text = "Buy";
        AtkHat.interactable= true;


    }

    IEnumerator PotionTimer()
    {
        float displayDurationforPotionSeconds = displayDurationforPotion * 60f;
        statsMenu.defenseLevel += 30;
        statsMenu.attackLevel += 30;
        statsMenu.magicLevel += 30;
        statsMenu.speedLevel += 10;
        potionText.text = "Sold Out";
        Potion.interactable = false;
        yield return new WaitForSeconds(displayDurationforPotionSeconds);
        statsMenu.defenseLevel -= 30;
        statsMenu.attackLevel -= 30;
        statsMenu.magicLevel -= 30;
        statsMenu.speedLevel -= 10;
        potionText.text = "Buy";
        Potion.interactable = true;

    }



    public static string FormatNumber(double num)
    {
        if (num >= 1000000000)
        {
            return (num / 1000000000D).ToString("0.#") + "B"; // Billion
        }
        if (num >= 1000000)
        {
            return (num / 1000000D).ToString("0.#") + "M"; // Million
        }
        if (num >= 1000)
        {
            return (num / 1000D).ToString("0.#") + "K"; // Thousand
        }

        return num.ToString("#,0"); // Numbers below 1000
    }
}
