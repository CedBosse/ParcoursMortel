using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeaponComponent : MonoBehaviour
{
    public GameObject sword;
    // Start is called before the first frame update
    void Awake()
    {
        /*hand = GameObject.FindGameObjectsWithTag("Grab")[0].transform;
        weapon = GameObject.FindGameObjectsWithTag("Weapon")[0];*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            collision.gameObject.SetActive(false);
            sword.SetActive(true);

        }
    }
}
