using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecker : MonoBehaviour
{
    ChangeScenes cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = GetComponent<ChangeScenes>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            if (collision.GetComponent<InventrySystem>().inventory.Count >= 3)
                cs.ChangeScene();
        }
    }
}
