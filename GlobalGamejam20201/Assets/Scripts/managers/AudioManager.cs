using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public sound[] sounds;

    public static AudioManager instance;

    public AudioMixer SFXVolume;

    public AudioMixer MusicVolume;

    void Awake()
    {


        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //s.source.volume = PlayerPrefs.GetFloat("volume", 1f);
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.audioMixer;


        }
    }

    public void Start()
    {
        SFXVolume.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("volume", 1)) * 20);
        //Play("Wind_1");
        //Play("Bad_Weather");
        //Play("Grass");
        //Play("Bird_1_Sound_1");
    }
    // Update is called once per frame
    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound: " + name + " not found! ");
            return;
        }

        s.source.Play();
    }
}
