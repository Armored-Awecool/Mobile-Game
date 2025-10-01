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


    public int attackLevel = 1;
    public int magicLevel = 1;
    public int defenseLevel = 1;
    public int speedLevel = 1;
    public double upgradeACost = 0.0;
    public double upgradeMCost = 0.0;
    public double upgradeDCost = 0.0;
    public double upgradeSCost = 0.0;

    void Start()
    {
        UpdateUI();
       
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
        // You would also update button text to show cost, etc.
    }

    public void UpgradeAttack()
    {
        // Check if player has enough currency/resources
        // if (playerCurrency >= upgradeCost)
        // {
        attackLevel++;
        // playerCurrency -= upgradeCost;
        UpdateUI();
        // }
        // else
        // {
        //     Debug.Log("Not enough currency!");
        // }
    }
    public void UpgradeMagic()
    {
        // Check if player has enough currency/resources
        // if (playerCurrency >= upgradeCost)
        // {
        magicLevel++;
        // playerCurrency -= upgradeCost;
        UpdateUI();
        // }
        // else
        // {
        //     Debug.Log("Not enough currency!");
        // }
    }
    public void UpgradeDefense()
    {
        // Check if player has enough currency/resources
        // if (playerCurrency >= upgradeCost)
        // {
        defenseLevel++;
        // playerCurrency -= upgradeCost;
        UpdateUI();
        // }
        // else
        // {
        //     Debug.Log("Not enough currency!");
        // }
    }
    public void UpgradeSpeed()
    {
        // Check if player has enough currency/resources
        // if (playerCurrency >= upgradeCost)
        // {
        speedLevel++;
        // playerCurrency -= upgradeCost;
        UpdateUI();
        // }
        // else
        // {
        //     Debug.Log("Not enough currency!");
        // }
    }


    public void loadGame()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(2);
    }
}





