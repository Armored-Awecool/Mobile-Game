using UnityEngine;
using UnityEngine.Timeline;

public class Barbarian : combatClass
{
    


    void Start()
    {
        Transform head = this.gameObject.GetComponent<playableCharacter>().head;
        attack = 20;

        magic = -2;

        atkSpeed = 0.9f;

        hp = 40;

        hat = Resources.Load<GameObject>("testHat");




        GameObject playerHat = Instantiate(hat);
        playerHat.transform.SetParent(head);

        playerHat.transform.localPosition = new Vector3(0, 0.5f, 0);

        this.gameObject.SendMessage("classAttack", attack);
        this.gameObject.SendMessage("classMagic", magic);
        this.gameObject.SendMessage("classAttackSpeed", atkSpeed);
        this.gameObject.SendMessage("classHealth", hp);
        this.gameObject.SendMessage("ResetSlider"); //Resets the HP slider
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
