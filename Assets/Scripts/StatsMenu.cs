using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
//is prefab
public class StatsMenu : MonoBehaviour
{
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI magicText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;

    public TextMeshProUGUI upgradeAText;
    public TextMeshProUGUI upgradeMText;
    public TextMeshProUGUI upgradeDText;
    public TextMeshProUGUI upgradeSText;

    public TextMeshProUGUI totalMoney;


    public int attackLevel;
    public int magicLevel;
    public int defenseLevel;
    public float speedLevel;
 //   public double upgradeACost = 0.0;
  //  public double upgradeMCost = 0.0;
  //  public double upgradeDCost = 0.0;
  //  public double upgradeSCost = 0.0;

    public double TotalMoneyCount
    {
        get => SAVE.SaveFile.Money;
        set => SAVE.SaveFile.Money = value;
        
    }
    public double upgradeACost
    {
        get => SAVE.SaveFile.attackMoney;
        set => SAVE.SaveFile.attackMoney = value;
    }
    public double upgradeMCost
    {
        get => SAVE.SaveFile.magicMoney;
        set =>SAVE.SaveFile.magicMoney = value;
    }
    public double upgradeDCost
    {
        get =>SAVE.SaveFile.defenseMoney;
        set => SAVE.SaveFile.defenseMoney = value;
    }
    public double upgradeSCost
    {
        get => SAVE.SaveFile.speedMoney;
        set => SAVE.SaveFile.speedMoney = value;
    }

    public SAVEMANAGER SAVE;

    public GameObject tooltipPanel; // Assign your UI panel for the tooltip
    public TextMeshProUGUI tooltipText; // Assign your TextMeshProUGUI component
    public float displayDuration = 3f; // Duration in seconds
    string FeedbackText;
    private bool needToStop;

    void Start()
    {
        UpdateUI();
        tooltipPanel.gameObject.SetActive(false);
        FeedbackText = "insufficient Funds\r\naka(You broke lil homie!)";
        needToStop = false;

        attackLevel = SAVE.SaveFile.Hero1.Attack;
        magicLevel = SAVE.SaveFile.Hero1.Magic;
        defenseLevel = SAVE.SaveFile.Hero1.Defense;
        speedLevel = SAVE.SaveFile.Hero1.Speed;
        UpdateUI();
         

    }

    void UpdateUI()
    {
        attackText.text = "Attack: " + attackLevel;
        magicText.text = "Magic: " + magicLevel;
        defenseText.text = "Defense: " + defenseLevel;
        speedText.text = "Speed: " + speedLevel;
        upgradeAText.text = "Upgrade for " + FormatNumber(upgradeACost);
        upgradeMText.text = "Upgrade for " + FormatNumber(upgradeMCost);
        upgradeDText.text = "Upgrade for " + FormatNumber(upgradeDCost);
        upgradeSText.text = "Upgrade for " + FormatNumber(upgradeSCost);
        totalMoney.text = "GoldAmount: " + FormatNumber(TotalMoneyCount);
        // You would also update button text to show cost, etc.
    }
    private void Update()
    {

    }
    public void Money()
    {

        SAVE.SaveFile.Money = TotalMoneyCount;
        SAVE.SaveFile.attackMoney = upgradeACost;
        SAVE.SaveFile.magicMoney = upgradeMCost;
        SAVE.SaveFile.defenseMoney = upgradeDCost;
        SAVE.SaveFile.speedMoney = upgradeSCost;

        UpdateUI();
    }
    public void UpgradeAttack()
    {

        if (TotalMoneyCount >= upgradeACost)
        {
            upgradeACost += 50;
            SAVE.addHero1Attack();
            attackLevel = SAVE.SaveFile.Hero1.Attack;
            TotalMoneyCount -= upgradeACost;
            UpdateUI();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }

    }
    public void UpgradeMagic()
    {
        if (TotalMoneyCount >= upgradeMCost)
        {
            upgradeMCost += 50;
            SAVE.addHero1Magic();
            magicLevel = SAVE.SaveFile.Hero1.Magic;
            TotalMoneyCount -= upgradeMCost;
            UpdateUI();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void UpgradeDefense()
    {
        if (TotalMoneyCount >= upgradeDCost)
        {
            upgradeDCost += 50;
            SAVE.addHero1Defense();
            defenseLevel = SAVE.SaveFile.Hero1.Defense;
            TotalMoneyCount -= upgradeDCost;
            UpdateUI();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }
    public void UpgradeSpeed()
    {
        if (TotalMoneyCount >= upgradeSCost)
        {
            upgradeSCost += 50;
            SAVE.addHero1Speed();
            speedLevel = SAVE.SaveFile.Hero1.Speed;
            TotalMoneyCount -= upgradeSCost;
            UpdateUI();
        }
        else
        {
            ShowTooltip(FeedbackText);
            needToStop = true;
        }
    }

    public void loadGame()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(3);
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





