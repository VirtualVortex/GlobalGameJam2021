using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        number = PlayerPrefs.GetInt("saveNum");

        if (audioSources.Length > 0) SwitchAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void ResetNumber() => PlayerPrefs.SetInt("saveNum", 0);

    public void SaveNumber()
    {
        Debug.Log(number + 1);
        PlayerPrefs.SetInt("saveNum", number + 1);
    }
}
