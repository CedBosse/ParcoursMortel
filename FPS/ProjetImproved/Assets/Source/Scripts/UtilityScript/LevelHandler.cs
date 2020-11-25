using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelHandler : MonoBehaviour
{
    private bool isTouchingGround;
    private bool isTouchingVictory;

    [SerializeField] private LayerMask deathTerrain;
    [SerializeField] private LayerMask winTerrain;
    [SerializeField] private ParticleSystem stars;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject crossHairCanvas;
    
    public Transform orientation;

    public Animator transition;
    public float transitionTime = 1f;
    public void CheckIfDead()
    {
        isTouchingGround = Physics.Raycast(transform.position, -orientation.up, 1f, deathTerrain);

        IEnumerator LoadLevel(int sceneNumber)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(sceneNumber);
        }

        if (isTouchingGround)
        {
            StartCoroutine(LoadLevel(6));
        }
    }
    public void CheckIfWin()
    {
        isTouchingVictory = Physics.Raycast(transform.position, -orientation.up, 0.2f, winTerrain);

        IEnumerator LoadWinScreen()
        {
            yield return new WaitForSeconds(1);
            Cursor.lockState = CursorLockMode.None;
            crossHairCanvas.SetActive(false);
            endScreen.SetActive(true);
        }

        if (isTouchingVictory)
        {
            stars.Play();
            StartCoroutine(LoadWinScreen());
        }

    }
}
