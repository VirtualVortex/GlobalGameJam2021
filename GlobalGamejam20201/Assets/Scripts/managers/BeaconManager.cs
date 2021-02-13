using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    int number;

    int reset;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("reset", 1);
        number = PlayerPrefs.GetInt("saveNum");

        if (audioSources.Length > 0) SwitchAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Switch between audio sources
    void SwitchAudio()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (i == number)
                audioSources[number].enabled = true;

            if (i != number)
                audioSources[i].enabled = false;
        }
    }

    //reset audio
    public void ResetNumber()
    {
        PlayerPrefs.SetInt("saveNum", 0);
        PlayerPrefs.SetInt("reset", 1);
    }

    public void SaveNumber()
    {
        Debug.Log(number + 1);
        PlayerPrefs.SetInt("saveNum", number + 1);
    }
}
