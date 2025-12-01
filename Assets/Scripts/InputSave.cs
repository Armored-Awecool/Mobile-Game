using TMPro;
using UnityEngine;

public class InputSave : MonoBehaviour
{
    public TMP_InputField inputField;
    public SAVEMANAGER SAVE;
    public PlayerSelect playerStats;
    public StatsMenu stats;

    bool isHero1;
     bool isHero2;
     bool isHero3;
    bool isHero4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SAVE.SaveFile.Hero1 = new SAVEMANAGER.Character(stats.attackLevel, stats.magicLevel, stats.defenseLevel, stats.speedLevel, 100, "Sword", "Bow", "Amulet", "Default");
       
            if (SAVE.SaveFile.Hero1.Equals(default(SAVEMANAGER.Character)))
        {
            string textToSave = inputField.text;
          
            Debug.Log("Saving: " + textToSave);
            PlayerPrefs.SetString("SavedText", textToSave);
            SAVE.CreateNewSave();
            stats.attackLevel = SAVE.SaveFile.Hero1.Attack;
            stats.magicLevel = SAVE.SaveFile.Hero1.Magic;
            stats.defenseLevel = SAVE.SaveFile.Hero1.Defense;
            stats.speedLevel = SAVE.SaveFile.Hero1.Speed; 
           SAVE.SaveGame();
        }
        else if (SAVE.SaveFile.Hero2.Equals(default(SAVEMANAGER.Character)))
        {
            string textToSave = inputField.text;

            Debug.Log("Saving: " + textToSave);
            PlayerPrefs.SetString("SavedText", textToSave);
            SAVE.CreateNewSave();
            stats.attackLevel = SAVE.SaveFile.Hero2.Attack;
            stats.magicLevel = SAVE.SaveFile.Hero2.Magic;
            stats.defenseLevel = SAVE.SaveFile.Hero2.Defense;
            stats.speedLevel = SAVE.SaveFile.Hero2.Speed;
            SAVE.SaveGame();
        }
        else if (SAVE.SaveFile.Hero3.Equals(default(SAVEMANAGER.Character)))
        {
            string textToSave = inputField.text;

            Debug.Log("Saving: " + textToSave);
            PlayerPrefs.SetString("SavedText", textToSave);
            SAVE.CreateNewSave();
            stats.attackLevel = SAVE.SaveFile.Hero3.Attack;
            stats.magicLevel = SAVE.SaveFile.Hero3.Magic;
            stats.defenseLevel = SAVE.SaveFile.Hero3.Defense;
            stats.speedLevel = SAVE.SaveFile.Hero3.Speed;
            SAVE.SaveGame();
        }
        else if (SAVE.SaveFile.Hero4.Equals(default(SAVEMANAGER.Character)))
        {
            string textToSave = inputField.text;

            Debug.Log("Saving: " + textToSave);
            PlayerPrefs.SetString("SavedText", textToSave);
            SAVE.CreateNewSave();
            stats.attackLevel += SAVE.SaveFile.Hero4.Attack;
            stats.magicLevel += SAVE.SaveFile.Hero4.Magic;
            stats.defenseLevel += SAVE.SaveFile.Hero4.Defense;
            stats.speedLevel += SAVE.SaveFile.Hero4.Speed;
            SAVE.SaveGame();
        }
        else
        {
           
            return;
            
        }
    }
    public void setSaveFile()
    {

    }
    public void Override()
    {
        if(isHero1)
        {
            SAVE.SaveFile.Hero1 = new SAVEMANAGER.Character();
        }
        if (isHero2)
        {
            SAVE.SaveFile.Hero2 = new SAVEMANAGER.Character();
        }
        if (isHero3)
        {
            SAVE.SaveFile.Hero3 = new SAVEMANAGER.Character();
        }
        if (isHero4)
        {
            SAVE.SaveFile.Hero4 = new SAVEMANAGER.Character();
        }
    }
  /*  public void Hero1Button()
    {
        isHero1 = true;
        Override();
    }
    public void Hero2Button()
    {
        isHero2 = true;
        Override();
    }
    public void Hero3Button()
    {
        isHero3 = true;
        Override();
    }
    public void Hero4Button()
    {
        isHero4 = true;
        Override();
    }
*/

}
