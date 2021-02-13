using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class UIButtons : MonoBehaviour
{
    public void RestartButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        Time.timeScale = 1;
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("MainLevel");
        Time.timeScale = 1;
    }
    
    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Back");
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        FindObjectOfType<AudioManager>().Play("Forward");
        SceneManager.LoadScene("Controls");
    }

    public void Settings()
    {
        FindObjectOfType<AudioManager>().Play("Forward");
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Forward");
        Application.Quit();
    }

    public void Credits()
    {
        FindObjectOfType<AudioManager>().Play("Forward");
        SceneManager.LoadScene("Credits");
    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Forward");
        SceneManager.LoadScene("MusicBuilding");
    }

}
