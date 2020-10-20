using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingComponent : MonoBehaviour
{
    public GameObject owner;
    private void OnTriggerEnter(Collider other)
    {
        if (owner.gameObject.tag == "Player" && other.gameObject.tag == "Ennemi")
            other.gameObject.SetActive(false);
        else if(owner.gameObject.tag == "Ennemi" && other.gameObject.tag == "Player")
            other.gameObject.SetActive(false);
    }
}
