using UnityEngine;
using System.IO;

public class SAVEMANAGER : MonoBehaviour
{
    [System.Serializable]
    public class Character //Class to save the data of an in game character
    {
        public int Attack;
        public int Magic;
        public int Defense;
        public int Speed;
        public int Health;
        //I made three equipment slots. These could go unused. Just so they exist.
        //Can add more if needed. Can stay here unused if not needed.
        public string Equip1;
        public string Equip2;
        public string Equip3;
        public string Hat;

        public Character()
        {
            Attack = 0;
            Magic = 0;
            Defense = 0;
            Speed = 0;
            Health = 0;
            Equip1 = "Empty";
            Equip2 = "Empty";
            Equip3 = "Empty";
            Hat = "Default";
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
        }
    }

    [System.Serializable]
    public class GameProg //Class to save progression not tied to an in game character
    {
        public int Money;//this is using totalMoneyCount from StatsMenu.
        public string EquipmentList;

        public GameProg()
        {
            Money = 0;
            EquipmentList = "";
        }

        public GameProg(int mon, string EL)
        {
            Money = mon;
            EquipmentList = EL;
        }
    }

    public Character Hero1;
    public Character Hero2;
    public Character Hero3;
    public Character Hero4;
    public GameProg SaveFile;

    //This method would be called to make a generic save.
    //Once we've decided the base stats for each character, those zeroes can be replaced.
    //For reference it goes: Attack, Magic, Defense, Speed, HP, Equip1, Equip2, Equip3, Hat.
    public void CreateNewSave()
    {
        Hero1 = new Character(0, 0, 0, 0, 0, "Empty", "Empty", "Empty", "Default");
        Hero2 = new Character(0, 0, 0, 0, 0, "Empty", "Empty", "Empty", "Default");
        Hero3 = new Character(0, 0, 0, 0, 0, "Empty", "Empty", "Empty", "Default");
        Hero4 = new Character(0, 0, 0, 0, 0, "Empty", "Empty", "Empty", "Default");
        SaveFile = new GameProg();
        SaveGame(); //It saves the game right after setting the default values.
        LoadGame(); //Then it loads the new save that was just made.
    }

    //Can be run any time we want the game to be saved to the file.
    //Turns everything into a json and saves each.
    public void SaveGame()
    {
        string json = JsonUtility.ToJson(Hero1);
        string FilePath = Path.Combine(Application.persistentDataPath, "Hero1.json");
        File.WriteAllText(FilePath, json);

        json = JsonUtility.ToJson(Hero2);
        FilePath = Path.Combine(Application.persistentDataPath, "Hero2.json");
        File.WriteAllText(FilePath, json);

        json = JsonUtility.ToJson(Hero3);
        FilePath = Path.Combine(Application.persistentDataPath, "Hero3.json");
        File.WriteAllText(FilePath, json);

        json = JsonUtility.ToJson(Hero4);
        FilePath = Path.Combine(Application.persistentDataPath, "Hero4.json");
        File.WriteAllText(FilePath, json);

        json = JsonUtility.ToJson(SaveFile);
        FilePath = Path.Combine(Application.persistentDataPath, "SaveFile.json");
        File.WriteAllText(FilePath, json);
    }

    //Same concept as SaveGame() just in reverse.
    public void LoadGame()
    {
        string FilePath = Path.Combine(Application.persistentDataPath, "Hero1.json");
        string json = File.ReadAllText(FilePath);
        Hero1 = JsonUtility.FromJson<Character>(json);

        FilePath = Path.Combine(Application.persistentDataPath, "Hero2.json");
        json = File.ReadAllText(FilePath);
        Hero2 = JsonUtility.FromJson<Character>(json);

        FilePath = Path.Combine(Application.persistentDataPath, "Hero3.json");
        json = File.ReadAllText(FilePath);
        Hero3 = JsonUtility.FromJson<Character>(json);

        FilePath = Path.Combine(Application.persistentDataPath, "Hero4.json");
        json = File.ReadAllText(FilePath);
        Hero4 = JsonUtility.FromJson<Character>(json);

        FilePath = Path.Combine(Application.persistentDataPath, "SaveFile.json");
        json = File.ReadAllText(FilePath);
        SaveFile = JsonUtility.FromJson<GameProg>(json);
    }



    //Below are scripts that may not be needed and could be redundant. I wish I knew. Intellisense isn't working.

    public Character getHero1()
    {
        return Hero1;
    }

    public Character getHero2()
    {
        return Hero2;
    }

    public Character getHero3()
    {
        return Hero3;
    }

    public Character getHero4()
    {
        return Hero4;
    }

    public GameProg getSaveFile()
    {
        return SaveFile;
    }


    //------------------------------------------------------------------------------------------------------------
    //ANYTHING UNDER THIS IS A TEST METHOD THAT WILL LIKELY NOT BE USED IN THE FINAL GAME!!!!!
    //They can be used as reference as to how this script can be used in other scripts, however.
    //^As these testing methods will represent the intended ways to use this, but accessing in other scripts.
    //For reference again, it goes: Attack, Magic, Defense, Speed, HP, Equip1, Equip2, Equip3, Hat.

    public void showHero1Stats()
    {
        Debug.Log("Attack: "+Hero1.Attack);
        Debug.Log("Magic: "+Hero1.Magic);
        Debug.Log("Defense: "+Hero1.Defense);
        Debug.Log("Speed: "+Hero1.Speed);
        Debug.Log("HP: "+Hero1.Health);
        Debug.Log("Equip1: "+Hero1.Equip1);
        Debug.Log("Equip2: "+Hero1.Equip2);
        Debug.Log("Equip3: "+Hero1.Equip3);
        Debug.Log("Hat: "+Hero1.Hat);
    }

    public void addHero1Attack()
    {
        Hero1.Attack += 1;
    }

    public void showSaveFileStats()
    {
        Debug.Log(SaveFile.Money);
        Debug.Log(SaveFile.EquipmentList);
    }

    public void addMoney()
    {
        SaveFile.Money += 1;
    }
}