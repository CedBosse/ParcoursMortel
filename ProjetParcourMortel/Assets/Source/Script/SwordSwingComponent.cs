using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingComponent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.tag);
       /* Debug.Log(collision.gameObject.tag);
        if (gameObject.tag == "Sword" && collision.gameObject.tag == "Ennemi")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("Ennemy touched");
        }         
        else if (gameObject.tag == "Ennemi" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("Player touched");
        }*/
    }
}
