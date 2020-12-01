using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerComponent : MonoBehaviour
{
    private Text txt;
    public int timer = 60;
    private float elapsed;
    private int counter = 0;

    [SerializeField] private LevelHandler levelHandler;
    void Awake()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (levelHandler.isTouchingVictory)
        {
            return;
        }
           
        
        txt.text = "Time : " + timer.ToString();
        elapsed += Time.deltaTime;
        if (elapsed >= 1)
        {
            timer--;
            elapsed = 0;
        }

        if (timer == 0)
            SceneManager.LoadScene(10);
    }
}
