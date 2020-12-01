﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    private Text txt;
    // Start is called before the first frame update
    void Awake()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Start()
    {
        txt.text = "Points: " + PlayerPrefs.GetInt("Score").ToString();
    }
}
