using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    [SerializeField] private Health bossHealth;
    [SerializeField] private GameObject over1;
    [SerializeField] private GameObject over2;
    [SerializeField] private GameObject over3;
    [SerializeField] private GameObject over4;

    public Animator transition;
    public float transitionTime = 1f;


    private int healCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PhaseTwo();
        CheckDeath();
    }
    private void PhaseTwo()
    {
        if(bossHealth.currentHealth <= 500)
        {
            if(healCounter < 1)
            {            
                over1.SetActive(true);
                over2.SetActive(true);
                over3.SetActive(true);
                over4.SetActive(true);
                bossHealth.currentHealth += 250;
                healCounter++;
            }

        }
    }
    private void CheckDeath()
    {
        if (bossHealth == null)
        {
            StartCoroutine(LoadLevel());
        }
    }
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(7);
    }
}
