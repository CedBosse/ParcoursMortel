using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    IEnumerator LoadLevel(int path)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(path);
    }
    public void Play()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();      
    }
    public void LevelSelect(int index)
    {
        StartCoroutine(LoadLevel(index));
    }
}
