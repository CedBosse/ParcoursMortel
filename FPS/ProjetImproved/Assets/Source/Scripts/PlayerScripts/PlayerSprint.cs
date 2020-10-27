using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;

    public bool toggle = false;


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Sprint();
    }

    void Sprint()
    {
        if (!toggle)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
               playerMovement.speed = sprintSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerMovement.speed = moveSpeed;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (playerMovement.speed == moveSpeed)
                    playerMovement.speed = sprintSpeed;
                else
                    playerMovement.speed = moveSpeed;
            }
        }

    }
}
