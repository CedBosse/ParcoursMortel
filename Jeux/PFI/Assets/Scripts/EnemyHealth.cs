using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 200;
    public Image image;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Punch")
    //    {
    //        health -= 10;
    //        image.fillAmount -= 0.1f;
    //    }
    //    else if(collision.gameObject.tag == "Kick")
    //    {
    //        health -= 15;
    //        image.fillAmount -= 0.15f;
    //    }
    //}
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        image.fillAmount -= dmg / 100;

    }

    private void Update()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
            //SceneManager.LoadScene(1);
        }
    }
}
