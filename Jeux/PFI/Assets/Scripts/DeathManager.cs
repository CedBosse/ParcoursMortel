using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Image imageAI;
    public Image imagePlayer;
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(LoadLevel());
    }

    void Update()
    {
        if(imageAI.fillAmount <= 0 || imagePlayer.fillAmount <= 0)
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(2);
    }
}
