using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatsScroller theBs;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text MultiText;

    public Slider progressBar;

    [HideInInspector]
    public float MaxNum = 100;

    public GameObject WonPanel;
    


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;
                AudioManager.instance.Play("Down");
                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");
        AudioManager.instance.Play("Hit");

        if (currentMultiplier -1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        MultiText.text = "Multiplier: x" + currentMultiplier;
        

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        progressBar.value += 5f;
        
        if(progressBar.value == MaxNum)
        {
            WonPanel.SetActive(true);
            theMusic.Stop();
            Time.timeScale = 0;
        }
    }

    public void NoteMissed()
    {
        Debug.Log("Missed note");
        AudioManager.instance.Play("Miss");
    }
}
