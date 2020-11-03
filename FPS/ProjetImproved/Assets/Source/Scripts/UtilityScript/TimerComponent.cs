using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerComponent : MonoBehaviour
{
    private Text txt;
    private int timer = 60;
    private float elapsed;
    void Awake()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        txt.text = "Time : " + timer.ToString();
        elapsed += Time.deltaTime;
        if (elapsed >= 1)
        {
            timer--;
            elapsed = 0;
        }

        if (timer == 0)
            SceneManager.LoadScene(0);
    }
}
