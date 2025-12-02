using Unity.VisualScripting;
using UnityEngine;
 using UnityEngine.InputSystem.EnhancedTouch;
 using UnityEngine.InputSystem;
 using TMPro;

public class touchHandler : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction touchAction;

    float touchTimer;
    float clickSpeed = 0.2f;

    public TMP_Text clickTip, holdTip;


    bool tap, hold;
    private float screenCenterX;
     void Awake()
    {
        TouchSimulation.Enable();
        touchAction = inputActions.FindAction("touchHeld");
    }

    void Start()
    {
        screenCenterX = Screen.width * 0.5f;
    }

    void OnEnable()
    {
        touchAction.Enable();
        touchAction.performed += OnTouchHeld;
        
    }

    void OnDisable()
    {
        touchAction.performed -= OnTouchHeld;
        touchAction.Disable();
    }

    private void OnTouchHeld(InputAction.CallbackContext context)
    {
        if(hold){
        Vector2 touchPosition = context.ReadValue<Vector2>();
        if (Time.time >= touchTimer + clickSpeed){
        if (touchPosition.x < Screen.width / 2)
        {
            Debug.Log("Left half of the screen is being held.");
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            int random = Random.Range(0, players.Length);
            playableCharacter player = players[random].GetComponent<playableCharacter>();
            player.clickSkill();
            touchTimer = Time.time;
        }
        else
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int random = Random.Range(0, enemies.Length);
            enemy enemyScript = enemies[random].GetComponent<enemy>();
            enemyScript.takeDamage((int)(enemyScript.healthBar.maxValue / 10));
            touchTimer = Time.time;
        }
        }
        }
    }

    public void enableTap()
    {
       tap = true;
       hold = false;
       foreach(GameObject pc in GameObject.FindGameObjectsWithTag("Player"))
       {
           playableCharacter character = pc.GetComponent<playableCharacter>();
           character.tap = true;
           character.hold = false;
       }
       foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
       {
           enemy.GetComponent<enemy>().tap = true;
           enemy.GetComponent<enemy>().hold = false;
       }
       clickTip.gameObject.SetActive(true);
       holdTip.gameObject.SetActive(false);
       
    }

    public void enableHold()
    {
       tap = false;
       hold = true;
       foreach(GameObject pc in GameObject.FindGameObjectsWithTag("Player"))
       {
           playableCharacter character = pc.GetComponent<playableCharacter>();
           character.tap = false;
           character.hold = true;
       }
       foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
       {
           enemy.GetComponent<enemy>().tap = false;
           enemy.GetComponent<enemy>().hold = true;
       }
         clickTip.gameObject.SetActive(false);
         holdTip.gameObject.SetActive(true);
    }


}
