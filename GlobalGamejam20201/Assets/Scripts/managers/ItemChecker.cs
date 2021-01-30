using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemChecker : MonoBehaviour
{
    public UnityEvent myEvent;

    public void InvokeEvent() => myEvent.Invoke();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            Debug.Log(collision.GetComponent<InventrySystem>().inventory.Count);
            if (collision.GetComponent<InventrySystem>().inventory.Count >= 3)
                InvokeEvent();
        }
    }
}
