using UnityEngine;
using System.IO;
using System.Collections.Generic;
//is prefab

public class SAVEMANAGER : MonoBehaviour
{
    void Start()
    {
        LoadGame();
        
    }

    [System.Serializable]
    public class Character //Class to save the data of an in game character
    {
        public int Attack;
        public int Magic;
        public int Defense;
        public float Speed;
        public int Health;
        //I made three equipment slots. These could go unused. Just so they exist.
        //Can add more if needed. Can stay here unused if not needed.
        public string Equip1;
        public string Equip2;
        public string Equip3;
        public string Hat;

        // public double attackUpgrade;
        // public double magicUpgrade;
        // public double defenseUpgrade;
        // public double speedUpgrade;


     

        public Character()
        {
            Attack = 0;
            Magic = 0;
            Defense = 0;
            Speed = 1;
            Health = 100;
            Equip1 = "Empty";
            Equip2 = "Empty";
            Equip3 = "Empty";
            Hat = "Default";

            //for the Upgrade MONEY amount
            // attackUpgrade = 0.0;
            // magicUpgrade = 0.0;
            // defenseUpgrade = 0.0;
            // speedUpgrade = 0.0;


        }

        public Character(int atk, int mag, int def, int spd, int hp, string e1, string e2, string e3, string ha)
        {
            Attack = atk;
            Magic = mag;
            Defense = def;
            Speed = spd;
            Health = hp;
            Equip1 = e1;
            Equip2 = e2;
            Equip3 = e3;
            Hat = ha;

            //for the Upgrade MONEY amount
            // attackUpgrade = aU;
            // magicUpgrade = mU;
            // defenseUpgrade = dU;
            // speedUpgrade = sU;
             

        }
    }

    [System.Serializable]
    public class GameProg // Class to save progression not tied to an in game character
    {
        public double Money; // this is using totalMoneyCount from StatsMenu.
        public double Jewel; // this is using totalJewelCount from StatsMenu.
        public string EquipmentList;
        public int LevelProg; //Lists how many levels the player has beat/shows which they are on

        //For upgrade money Amount in StatsMenu
        public double attackMoney;
        public double magicMoney;
        public double defenseMoney;
        public double speedMoney;

        public Character Hero1;
        public Character Hero2;
        public Character Hero3;
        public Character Hero4;

     

        public GameProg()
        {
            Hero1 = new Character(0, 0, 0, 5, 100, "Empty", "Empty", "Empty", "Default");
            Hero2 = new Character(0, 0, 0, 0, 0, "Empty", "Empty", "Empty", "Default");
            Hero3 = new Character(0, 0, 0, 0, 0, "Empty", "Empty", "Empty", "Default");
            Hero4 = new Character(0, 0, 0, 0, 0, "Empty", "Empty", "Empty", "Default");
            Money = 0;
            Jewel = 0;
            EquipmentList = "";
            LevelProg = 0;
        }

        // public GameProg(double mon, List<string> EL) : this()
        // {
        //     Money = mon;
        //     EquipmentList = EL;
        // }
    }


    [SerializeReference] public GameProg SaveFile;

    //This method would be called to make a generic save.
    //Once we've decided the base stats for each character, those zeroes can be replaced.
    //For reference it goes: Attack, Magic, Defense, Speed, HP, Equip1, Equip2, Equip3, Hat.
    public void CreateNewSave()
    {

        SaveFile = new GameProg();
        Debug.Log("New Save");
        SaveGame(); //It saves the game right after setting the default values.
        LoadGame(); //Then it loads the new save that was just made.
    }

    //Can be run any time we want the game to be saved to the file.
    //Turns everything into a json and saves each.
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(SaveFile, true);
        string FilePath = Path.Combine(Application.persistentDataPath, "SaveFile.json");
        File.WriteAllText(FilePath, json);
    }

    //Same concept as SaveGame() just in reverse.
    public void LoadGame()
    {
        try
        {
            string FilePath = Path.Combine(Application.persistentDataPath, "SaveFile.json");
            string json = File.ReadAllText(FilePath);
            SaveFile = JsonUtility.FromJson<GameProg>(json);
        }
        catch (System.Exception)
        {
            SaveFile = new GameProg();
            SaveGame();
        }
    }



    //------------------------------------------------------------------------------------------------------------
    //ANYTHING UNDER THIS IS A TEST METHOD THAT WILL LIKELY NOT BE USED IN THE FINAL GAME!!!!!
    //They can be used as reference as to how this script can be used in other scripts, however.
    //^As these testing methods will represent the intended ways to use this, but accessing in other scripts.
    //For reference again, it goes: Attack, Magic, Defense, Speed, HP, Equip1, Equip2, Equip3, Hat.

    public void showHero1Stats()
    {
        Debug.Log("Attack: " + SaveFile.Hero1.Attack);
        Debug.Log("Magic: " + SaveFile.Hero1.Magic);
        Debug.Log("Defense: " + SaveFile.Hero1.Defense);
        Debug.Log("Speed: " + SaveFile.Hero1.Speed);
        Debug.Log("HP: " + SaveFile.Hero1.Health);
        Debug.Log("Equip1: " + SaveFile.Hero1.Equip1);
        Debug.Log("Equip2: " + SaveFile.Hero1.Equip2);
        Debug.Log("Equip3: " + SaveFile.Hero1.Equip3);
        Debug.Log("Hat: " + SaveFile.Hero1.Hat);
    }

    public void addHero1Attack()
    {
        SaveFile.Hero1.Attack += 1;
        SaveGame();
    }

    public void addHero1Magic()
    {
        SaveFile.Hero1.Magic += 1;
        SaveGame();
    }

    public void addHero1Speed()
    {
        SaveFile.Hero1.Speed -= 0.05f;
        SaveGame();
    }

    public void addHero1Defense()
    {
        SaveFile.Hero1.Defense += 1;
        SaveGame();
    }

    public void showSaveFileStats()
    {
        Debug.Log(SaveFile.Money);
        Debug.Log(SaveFile.EquipmentList);
        Debug.Log(SaveFile.LevelProg);
    }

    public void addMoney(int money)
    {
        SaveFile.Money += money;
    }
}