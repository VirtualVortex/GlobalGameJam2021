using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class sound
{
        public string name;

        public AudioClip clip;


        //public float volume;
        //[Range(0.1f, 3f)]
        //public float pitch;

        public AudioMixerGroup audioMixer;

        public bool loop;

        [HideInInspector]
        public AudioSource source;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    
}
