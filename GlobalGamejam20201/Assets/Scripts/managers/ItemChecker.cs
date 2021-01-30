using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemChecker : MonoBehaviour
{
    public UnityEvent myEvent;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            if (collision.GetComponent<InventrySystem>().inventory.Count >= 3)
                myEvent.Invoke();
        }
    }
}
