using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 200;
    public Image image;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Punch")
        {
            health -= 10;
            image.fillAmount -= 0.1f;
        }
        else if(collision.gameObject.tag == "Kick")
        {
            health -= 15;
            image.fillAmount -= 0.15f;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene(1);
        }
    }
}
