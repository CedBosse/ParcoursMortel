using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead = false;
    public Transform spawnPoint;

    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Length;
    }
    IEnumerator LoadLevel(int sceneNumber)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneNumber);
    }
    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            if (PlayerPrefs.GetInt("HighScore", 0) < PlayerPrefs.GetInt("TotalScore"))
            {
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("TotalScore", 0));
            }
            
            StartCoroutine(LoadLevel(10));
        }
    }

    public void LoseHeart(int d)
    {
        if (life >= 1)
        {
            life -= d;
            hearts[life].SetActive(false);
            if (life < 1)
            {
                dead = true;
            }
        }
    }
    public void FillLives()
    {
            if (!hearts[2].activeSelf && (hearts[0].activeSelf && hearts[1].activeSelf))
            {
                hearts[2].SetActive(true);
                life++;
            }
            else if(!hearts[2].activeSelf && !hearts[1].activeSelf && hearts[0].activeSelf)
            {
                hearts[1].SetActive(true);
                life++;
            }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Life")
        {
            FillLives();
            hit.gameObject.SetActive(false);
        }
    }
}
