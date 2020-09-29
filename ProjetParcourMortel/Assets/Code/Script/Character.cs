using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    private float forwardInput;
    private float rightInput;

    private Vector3 velocity;
    private Vector3 translation;

    private Vector3 camFwd;
    private Vector3 camRight;

    public CameraController cameraController;
    public CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        //cameraController = GetComponentInChildren<CameraController>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void AddMovementInput(float forward, float right)
    {
        forwardInput = forward;
        rightInput = right;

        camFwd = cameraController.transform.forward;
        camRight = cameraController.transform.right;

        translation = forward * cameraController.transform.forward;
        translation += right * cameraController.transform.right;
        translation.y = 0;

        if(translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }
        
        characterMovement.Velocity = translation;

    } 
    public float getVelocity()
    {
        Debug.Log(velocity.magnitude);
        return velocity.magnitude;
    }
}
