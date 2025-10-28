using UnityEngine;
using UnityEngine.Timeline;

public class Wizard : combatClass
{


    void Start()
    {
        attack = -4;

        magic = 40;

        atkSpeed = 1.2f;

        hp = 10;

        hat = Resources.Load<GameObject>("wizardTestHat");




        GameObject playerHat = Instantiate(hat);
        playerHat.transform.SetParent(this.gameObject.transform);

        playerHat.transform.localPosition = new Vector3(0, 1f, 0);

        this.gameObject.SendMessage("classAttack", attack);
        this.gameObject.SendMessage("classMagic", magic);
        this.gameObject.SendMessage("classAttackSpeed", atkSpeed);
        this.gameObject.SendMessage("classHealth", hp);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
