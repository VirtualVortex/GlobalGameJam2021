using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class InventrySystem : MonoBehaviour
{
    [SerializeField]
    AudioClip audio;
    [SerializeField]
    List<Image> slots = new List<Image>();

    [HideInInspector]
    public Dictionary<string, Item> inventory = new Dictionary<string, Item>();
    [HideInInspector] public int amount;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void AddItem(Item item)
    {
        inventory.Add(item.itemName, item);
        amount = inventory.Count;
    }

    void ShowItems()
    {
        int i = 0;

        foreach (string key in inventory.Keys)
        {
            slots[i].sprite = inventory[key].itemImg;
            i++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.GetComponent<StoreItemData>() != null)
        {
            Debug.Log(collision.transform.GetComponent<StoreItemData>().item.itemName);
            AddItem(collision.transform.GetComponent<StoreItemData>().item);
            //ShowItems();
            Destroy(collision.gameObject);
            PlayAudio();
        }
    }

    void PlayAudio() 
    {
        audioSource.clip = audio;
        audioSource.Play();
        audioSource.loop = false;
    }
}
