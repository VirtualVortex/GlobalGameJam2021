using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemChecker : MonoBehaviour
{
    public UnityEvent myEvent;

    public void InvokeEvent() => myEvent.Invoke();

    SpaceShipTrigger ssT;

    private void Start() => ssT = GetComponent<SpaceShipTrigger>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            Debug.Log(collision.GetComponent<InventrySystem>().inventory.Count);
            if (collision.GetComponent<InventrySystem>().amount >= 3)
            {
                ssT.CanLeave();
                InvokeEvent();
            }
        }
    }
}
