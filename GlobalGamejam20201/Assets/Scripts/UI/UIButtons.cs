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
        AudioManager.instance.Play("Back");
        StartCoroutine(MainMenuSound());
        
       
    }

    IEnumerator MainMenuSound()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

}
