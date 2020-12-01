using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    IEnumerator LoadLevel(int sceneNumber)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneNumber);
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(scene.buildIndex + 1));
    }

    public void MainMenu()
    {
        StartCoroutine(LoadLevel(9));
    }
}
