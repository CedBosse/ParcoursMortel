using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charact : MonoBehaviour
{
    private float forwardInput;
    private float rightInput;

    private Vector3 velocity;

    public CameraController camController;
    public CharacterMovement characterMovement;
    public CharacterAnimationController characterAnimation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(velocity * Time.deltaTime);
    }
    public void AddMovementInput(float forward, float right)
    {
        forwardInput = forward;
        rightInput = right;

        Vector3 camFwd = camController.transform.forward;
        Vector3 camRight = camController.transform.right;

        Vector3 translation = forward * camController.transform.forward;
        translation += right * camController.transform.right;
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
        return characterMovement.Velocity.magnitude;
    }
    public void ToggleRun()
    {
        if (characterMovement.GetMovementMode() != MovementMode.Running)
        {
            characterMovement.SetMovementMode(MovementMode.Running);
        }
        else
        {
            characterMovement.SetMovementMode(MovementMode.Walking);
        }
    }
    public void Jump()
    {
        characterMovement.Jump();
        characterAnimation.Jump();
    }
}
