using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathComponent : MonoBehaviour
{
    public ChronoComponent chronoValue;
    public Text _texte;
    public  GameObject panel;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bad")
        {
            _texte.gameObject.SetActive(true);
            _texte.text = "You did " + chronoValue.GetScore().ToString();
            panel.SetActive(true);
            chronoValue.ResetText();
            chronoValue.Die();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
    }
}
