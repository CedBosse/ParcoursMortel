using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalScore : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Start()
    {
        tmp.text = "Final Score: " + PlayerPrefs.GetInt("TotalScore").ToString();

    }
}
