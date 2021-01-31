using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;




public class SaveLoadSystem : MonoBehaviour
{
    
    public PlayerMovement player;
    public Transform ship;
    public InventrySystem inventry;

    [Header("Reset")]
    public bool Reset = false;
    public Vector2 startPlayerPos, startShipPos;

    [HideInInspector] public bool level1Complete, level2Complete, level3Complete;

    string curScene;

    // Use this for initialization
    void Start() => DontDestroyOnLoad(this.gameObject);


    // Update is called once per frame
    void Update()
    {
        if (curScene != SceneManager.GetActiveScene().name && curScene != "MainMenu")
            LoadData();
    }

    private void LateUpdate()
    {
        curScene = SceneManager.GetActiveScene().name;
    }
    
    public void SaveData()
    {
        //player prefs saving method
        //Save which animals the player has and conver the booleans to int 
        //true = 1 and false = 0;
        PlayerPrefs.SetFloat("X", player.transform.position.x);
        PlayerPrefs.SetFloat("Y", player.transform.position.y);
        PlayerPrefs.SetFloat("shipX", ship.position.x);
        PlayerPrefs.SetFloat("shipY", ship.position.y);
        PlayerPrefs.SetInt("inventoryAmount", inventry.amount);
        PlayerPrefs.SetString("level1Complete", level1Complete.ToString());
        PlayerPrefs.SetString("level2Complete", level2Complete.ToString());
        PlayerPrefs.SetString("level3Complete", level3Complete.ToString());

        //write all the information saved above to disk
        PlayerPrefs.Save();
    }
    
    public void LoadData()
    {
        //player prefs way of saving data
        if (player != null)
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"));

        if(ship != null)
            ship.position = new Vector2(PlayerPrefs.GetFloat("shipX"), PlayerPrefs.GetFloat("shipY"));

        if (inventry != null)
        {
            inventry.amount = PlayerPrefs.GetInt("inventoryAmount", 3);
            Debug.Log(inventry.amount);
            if (inventry.amount >= 3)
            {
                foreach (StoreItemData data in FindObjectsOfType<StoreItemData>())
                    Destroy(data.gameObject);
            }
        }

        level1Complete = Convert.ToBoolean(PlayerPrefs.GetString("level1Complete"));
        level2Complete = Convert.ToBoolean(PlayerPrefs.GetString("level2Complete"));
        level3Complete = Convert.ToBoolean(PlayerPrefs.GetString("level3Complete"));
    }
    
    public void NewGame()
    {
        PlayerPrefs.SetFloat("X", startPlayerPos.x);
        PlayerPrefs.SetFloat("Y", startPlayerPos.y);
        PlayerPrefs.SetFloat("shipX", startShipPos.x);
        PlayerPrefs.SetFloat("shipY", startShipPos.y);
        PlayerPrefs.SetInt("inventoryAmount", 0);
        PlayerPrefs.SetString("level1Complete", false.ToString());
        PlayerPrefs.SetString("level2Complete", false.ToString());
        PlayerPrefs.SetString("level3Complete", false.ToString());
    }

    public void Level1Complete() => level1Complete = true;
    public void Level2Complete() => level2Complete = true;
    public void Level3Complete() => level3Complete = true;

}
