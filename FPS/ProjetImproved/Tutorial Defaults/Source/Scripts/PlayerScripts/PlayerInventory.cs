using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<string> inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Axe" || hit.gameObject.tag == "Revolver" || hit.gameObject.tag == "Shotgun" || hit.gameObject.tag == "Assault Rifle")
        {
            inventory.Add(hit.gameObject.tag);
            hit.gameObject.SetActive(false);
        }
    }
}
