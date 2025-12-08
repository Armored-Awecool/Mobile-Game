using Unity.VisualScripting;
using UnityEngine;
 using UnityEngine.InputSystem.EnhancedTouch;
 using UnityEngine.InputSystem;
 using TMPro;

public class touchHandler : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction touchAction;

    float objectTouchTimer;
    float screenTouchTimer;
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
        tap = true;
        hold = false;
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
        Vector2 touchPosition = context.ReadValue<Vector2>();
        if(tap)
        {
            TryHandleObjectTouch(touchPosition);
        }
        else
        TryHandleScreenHold(touchPosition);
    }

    private bool TryHandleObjectTouch(Vector2 touchPosition)
    {
        Camera cam = Camera.main;
        if (cam == null) return false;

        Ray ray = cam.ScreenPointToRay(touchPosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return false;

        GameObject hitObj = hit.collider.gameObject;

        if (Time.time < objectTouchTimer + clickSpeed) return false;

        if (hitObj.CompareTag("Player"))
        {
            playableCharacter player = hitObj.GetComponent<playableCharacter>();
            if (player != null)
            {
                player.clickSkill();
                Debug.Log("Touched player: " + hitObj.name);
                objectTouchTimer = Time.time;
                return true;
            }
        }
        else if (hitObj.CompareTag("Enemy"))
        {
            enemy enemyScript = hitObj.GetComponent<enemy>();
            if (enemyScript != null && enemyScript.healthBar != null)
            {
                enemyScript.takeDamage((int)(enemyScript.healthBar.maxValue / 10));
                objectTouchTimer = Time.time;
                return true;
            }
        }

        return false;
    }

    private bool TryHandleScreenHold(Vector2 touchPosition)
    {
        if (Time.time < screenTouchTimer + clickSpeed) return false;

        if (touchPosition.x < Screen.width / 2)
        {
            Debug.Log("Left half of the screen is being held.");
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 0)
            {
                int random = Random.Range(0, players.Length);
                playableCharacter player = players[random].GetComponent<playableCharacter>();
                if (player != null) player.clickSkill();
                screenTouchTimer = Time.time;
                return true;
            }
        }
        else
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                int random = Random.Range(0, enemies.Length);
                enemy enemyScript = enemies[random].GetComponent<enemy>();
                if (enemyScript != null && enemyScript.healthBar != null)
                    enemyScript.takeDamage((int)(enemyScript.healthBar.maxValue / 10));
                screenTouchTimer = Time.time;
                return true;
            }
        }

        return false;
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
