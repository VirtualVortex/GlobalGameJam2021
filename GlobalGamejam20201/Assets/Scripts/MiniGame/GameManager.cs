using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatsScroller theBs;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;
    public Text MultiText;

    public Slider progressBar;

    public float MaxNum = 100;

    public GameObject WonPanel;
    public GameObject RestartPanel;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On time");

        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
        progressBar.value += 10f;
        
        if(progressBar.value == MaxNum)
        {
            WonPanel.SetActive(true);
            theMusic.Stop();
        }
        /*else
        {
            RestartPanel.SetActive(true);
            theMusic.Stop();
        }*/

    }

    public void NoteMissed()
    {
        Debug.Log("Missed note");
    }
}
