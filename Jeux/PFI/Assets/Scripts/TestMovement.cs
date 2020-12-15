using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;


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
    }

}
