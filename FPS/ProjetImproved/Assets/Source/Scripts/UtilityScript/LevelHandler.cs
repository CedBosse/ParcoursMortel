using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelHandler : MonoBehaviour
{
    private bool isTouchingGround;
    public bool isTouchingVictory;

    [SerializeField] private HeartManager lives;
    [SerializeField] private LayerMask deathTerrain;
    [SerializeField] private LayerMask winTerrain;
    [SerializeField] private ParticleSystem stars;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject crossHairCanvas;
    [SerializeField] private Transform player;
    [SerializeField] private TimerComponent timerComponent;
    
    public Transform orientation;

    public Animator transition;
    public float transitionTime = 1f;
    private int counter = 0;


    public void CheckIfDead()
    {
        isTouchingGround = Physics.Raycast(transform.position, -orientation.up, 1f, deathTerrain);

        if (isTouchingGround)
        {
            Respawn(); 
            lives.LoseHeart(1);             
        }
    }
    public void Respawn()
    {
        transform.position = new Vector3(lives.spawnPoint.transform.position.x, lives.spawnPoint.transform.position.y, lives.spawnPoint.transform.position.z);
    }
    public void CheckIfWin()
    {
        isTouchingVictory = Physics.Raycast(transform.position, -orientation.up, 0.2f, winTerrain);

        IEnumerator LoadWinScreen()
        {
            yield return new WaitForSeconds(1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //crossHairCanvas.SetActive(false);
            AddScore();
            Debug.Log(PlayerPrefs.GetInt("TotalScore"));
            endScreen.SetActive(true);
        }

        if (isTouchingVictory)
        {          
            stars.Play();
            StartCoroutine(LoadWinScreen());
        }

    }
    private void AddScore()
    {
        if(counter < 1)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + timerComponent.timer);
            PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore", 0) + PlayerPrefs.GetInt("Score"));
            counter++;
        }
    }
}
