using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoComponent : MonoBehaviour
{
    private Text txt;
    private float elapsed = 0;
    private int score = 0;
    private bool isDead = false;
    void Awake()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= 1 && !isDead)
        {
            elapsed = 0;
            score++;
            txt.text = "Score : " + score;
        }
    }
    public int GetScore() => score;
    public void ResetText() { txt.text = ""; }
    public void Die() { isDead = true; }
}
