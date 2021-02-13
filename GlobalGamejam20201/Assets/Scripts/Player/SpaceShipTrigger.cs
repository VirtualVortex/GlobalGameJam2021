using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceShipTrigger : MonoBehaviour
{
    [SerializeField]
    KeyCode key;
    public float speedAddative;
    [SerializeField] float xOffset;
    [SerializeField]
    FloatVariable playerSpeed;

    [HideInInspector] public bool canUse;

    public UnityEvent enterShip;
    public UnityEvent leaveShip;

    bool isShip, canLeave;
    Collider2D col;
    PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        isShip = false;
        CanLeave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && isShip && canLeave)
            LeaveShip();
        
    }

    void EnterShip(Collider2D col)
    {
        playerSpeed.value += speedAddative;
        isShip = true;
        enterShip.Invoke();
        transform.position = new Vector3(col.transform.position.x, col.transform.position.y, transform.position.z);
    }

    void LeaveShip()
    {
        Debug.Log("Leave ship");
        playerSpeed.value -= speedAddative;
        isShip = false;
        transform.parent = null;
        col.transform.localPosition += Vector3.right * xOffset;
        col = null;
        pm = null;
        leaveShip.Invoke();

    }

    //To be use for unity event
    public void CanLeave() => canUse = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isShip && collision.tag.Contains("Player") && canUse)
        {
            Debug.Log("Enter ship");
            FindObjectOfType<AudioManager>().Play("TakeOff");
            col = collision;
            EnterShip(collision);
            pm = GetComponentInParent<PlayerMovement>();
        }

        if (collision.transform.tag.Contains("Landing")) canLeave = true;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag.Contains("Landing"))
            FindObjectOfType<AudioManager>().Play("Landing");
            canLeave = false;
    }
    
}
