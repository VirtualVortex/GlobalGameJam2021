using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] bool trigger;
    [SerializeField] string sceneName;
    [SerializeField] UnityEvent changingSceneEvent;

    public void ChangeScene()
    {
        changingSceneEvent.Invoke();
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player") && trigger) ChangeScene();
    }
}
