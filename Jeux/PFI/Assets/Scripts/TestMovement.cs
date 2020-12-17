using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    private MeshCollider collider;
    private float elapsed = 0;
    private GameObject platform;


    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Smash");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Kick");
        }
        Phase();
    }
    private void OnCollisionEnter(Collision collision)
    {
          collider.enabled = true;
    }
    private void Phase()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit))
        {
            if(hit.transform.tag == "Phaseable")
            {
                platform = hit.transform.gameObject;               
            }
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {      
            collider = platform.GetComponent<MeshCollider>();     
            collider.enabled = false;
            
        }
    }

}
