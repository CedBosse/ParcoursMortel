﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public enum MovementMode { Walking, Running};

[RequireComponent(typeof(Rigidbody))] 

public class CharacterMovement : MonoBehaviour
{
    public Transform t_Mesh;
    public float maxSpeed;
    private float smoothSpeed;
    public float rotationMultiplier;
    public float jumpForce = 100;

    private Rigidbody rigidBody;

    private Vector3 velocity;
    private MovementMode movementMode;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        

        if(velocity.magnitude > 0)
        {
            rigidBody.velocity = new Vector3(velocity.normalized.x * smoothSpeed, velocity.normalized.y, velocity.normalized.z * smoothSpeed);
            smoothSpeed = Mathf.Lerp(smoothSpeed, maxSpeed, Time.deltaTime * 4);
            t_Mesh.rotation = Quaternion.Lerp(t_Mesh.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationMultiplier);
        }
        else
        {
            smoothSpeed = Mathf.Lerp(smoothSpeed, 0, Time.deltaTime * 100);
        }
    }
    public Vector3 Velocity { get => rigidBody.velocity; set => velocity = value; }

    public void SetMovementMode(MovementMode mode)
    {
        movementMode = mode;
        switch (mode)
        {
            case MovementMode.Walking:
                maxSpeed = 20f;
                break;
            case MovementMode.Running:
                maxSpeed = 40f;
                break;
        }
    }
    public MovementMode GetMovementMode()
    {
        return movementMode;
    }
    public void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpForce);
    }
}

