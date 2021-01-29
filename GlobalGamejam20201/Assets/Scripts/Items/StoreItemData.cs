using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemData : MonoBehaviour
{
    public Item item;

    [HideInInspector]
    public string name;
    [HideInInspector]
    public Sprite img;

    // Start is called before the first frame update
    void Start()
    {
        name = item.itemName;
        img = item.itemImg;

        GetComponent<SpriteRenderer>().sprite = img;
    }
}
