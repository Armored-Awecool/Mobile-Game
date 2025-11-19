using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public TextMeshProUGUI totalMoney;
    public SAVEMANAGER SAVE;
    public double TotalMoneyCount
    {
        get => SAVE.SaveFile.Money;
        set => SAVE.SaveFile.Money = value;

    }


    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        totalMoney.text = "GoldAmount: " + FormatNumber(TotalMoneyCount);
        // You would also update button text to show cost, etc.
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
