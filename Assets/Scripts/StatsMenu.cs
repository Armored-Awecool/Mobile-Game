using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
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


    public int attackLevel = 1;
    public int magicLevel = 1;
    public int defenseLevel = 1;
    public int speedLevel = 1;
    public double upgradeACost = 0.0;
    public double upgradeMCost = 0.0;
    public double upgradeDCost = 0.0;
    public double upgradeSCost = 0.0;

    public double totalMoneyCount = 0;
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

    }

    void UpdateUI()
    {
        attackText.text = "Attack: " + attackLevel;
        magicText.text = "Magic: " + magicLevel;
        defenseText.text = "Defense: " + defenseLevel;
        speedText.text = "Speed: " + speedLevel;
        upgradeAText.text = "Upgrade for " + upgradeACost + "K";
        upgradeMText.text = "Upgrade for " + upgradeMCost + "K";
        upgradeDText.text = "Upgrade for " + upgradeDCost + "K";
        upgradeSText.text = "Upgrade for " + upgradeSCost + "K";
        totalMoney.text = "GoldAmount: " + totalMoneyCount + "K";
        // You would also update button text to show cost, etc.
    }
    private void Update()
    {
        
    }
    public void Money()
    {
        
        SAVE.SaveFile.Money = (int)totalMoneyCount;
   
        UpdateUI();
    }
    public void UpgradeAttack()
    {
       
         if (totalMoneyCount >= upgradeACost)
        {
            attackLevel++;
         totalMoneyCount -= upgradeACost;
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
        if (totalMoneyCount >= upgradeMCost)
        {
            magicLevel++;
            totalMoneyCount -= upgradeMCost;
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
        if (totalMoneyCount >= upgradeDCost)
        {
            defenseLevel++;
            totalMoneyCount -= upgradeDCost;
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
        if (totalMoneyCount >= upgradeSCost)
        {
            speedLevel++;
            totalMoneyCount -= upgradeSCost;
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

}





