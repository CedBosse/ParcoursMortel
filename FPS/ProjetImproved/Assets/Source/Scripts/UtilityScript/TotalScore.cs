using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
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
        txt.text = "Total: " + PlayerPrefs.GetInt("TotalScore").ToString();

    }
}
