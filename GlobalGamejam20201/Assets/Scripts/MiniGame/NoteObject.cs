using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool CanBePressed;

    public KeyCode keyToPress;

    public GameManager manager;

    public GameObject RestartPanel;

    private void Start()
    {
        RestartPanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(CanBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            CanBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            CanBePressed = false;
            GameManager.instance.NoteMissed();
        }

        if(tag == "LastArrow" && manager.progressBar.value < 100)
        {
            RestartPanel.SetActive(true);
            manager.theMusic.Stop();
            Time.timeScale = 0;
        }

    }
}
