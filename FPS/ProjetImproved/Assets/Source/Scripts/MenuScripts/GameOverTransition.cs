using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    IEnumerator LoadLevel(int sceneNumber)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneNumber);
    }

    public void Recommencer()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void MainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }
}
