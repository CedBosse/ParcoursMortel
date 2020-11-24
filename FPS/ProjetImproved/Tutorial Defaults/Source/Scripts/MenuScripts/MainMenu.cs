using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(2);
    }
    public void Play()
    {
        StartCoroutine(LoadLevel());
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();      
    }
}
