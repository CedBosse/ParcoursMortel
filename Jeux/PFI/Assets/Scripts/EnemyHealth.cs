using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 200;
    public Image image;

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
        }
    }
}
