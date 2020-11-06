using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterAnimationController : MonoBehaviour
{

    public Animator animator;
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {      

        if (animator == null)
        {
           // Debug.LogWarning("no valid animator");
        }

        animator.SetFloat("Velocity", character.getVelocity());
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Swing()
    {
        animator.SetTrigger("Swing");
    }
}
