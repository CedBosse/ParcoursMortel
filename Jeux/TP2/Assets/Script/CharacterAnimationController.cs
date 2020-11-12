using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charact))]
public class CharacterAnimationController : MonoBehaviour
{

    public Animator animator;
    private Charact character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Charact>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (animator == null)
        {
            Debug.LogWarning("no valid animator");
            return;
        }
        
        animator.SetFloat("Velocity", character.getVelocity());
    }
    public void Jump()
    {      
        animator.SetTrigger("Jump");
    }
}
