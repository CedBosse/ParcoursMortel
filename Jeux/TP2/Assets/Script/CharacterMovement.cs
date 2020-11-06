using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public enum MovementMode { Walking, Running};

[RequireComponent(typeof(Rigidbody))] 

public class CharacterMovement : MonoBehaviour
{

    
    private Vector3 velocity;
    public Transform t_mesh;
    public float maxSpeed;
   
    private float smoothSpeed;
    private float rotationMultiplier = 10;
    
    public float jumpForce = 100;

    private Rigidbody rigidbody;

    private MovementMode movementMode;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {       

        if(velocity.magnitude > 0)
        {
            rigidbody.velocity = new Vector3 (velocity.normalized.x * smoothSpeed, rigidbody.velocity.y, velocity.normalized.z * smoothSpeed);
            smoothSpeed = Mathf.Lerp(smoothSpeed, maxSpeed, Time.deltaTime);
            t_mesh.rotation = Quaternion.Lerp(t_mesh.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationMultiplier);
        }
        else
        {
            smoothSpeed = Mathf.Lerp(smoothSpeed, 0, Time.deltaTime);
        }
    }
    
    public Vector3 Velocity { get => rigidbody.velocity; set => velocity = value; }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce);
    }

    public void setMovementMode(MovementMode mode)
    {
        movementMode = mode;
        switch (mode)
        {
            case MovementMode.Walking:
                {
                    maxSpeed = 5;
                    break;
                }
            case MovementMode.Running:
                {
                    maxSpeed = 10;
                    break;
                }              
        }
    }
    public MovementMode GetMovementMode()
    {
        return movementMode;
    }
}
