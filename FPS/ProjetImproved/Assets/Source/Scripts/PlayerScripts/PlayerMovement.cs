using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float NORMAL_FOV = 60f;
    private const float HOOKSHOT_FOV = 100f;

    private Rigidbody rb;
    public Transform orientation;
    bool allowDashForceCounter;

    [SerializeField] private Transform hookshotTransform;

    private CharacterController characterController;

    private Vector3 moveDirection;

    public float speed = 5f;
    private float gravity = 20f;

    public float jumpForce = 10f;
    private float verticalVelocity;
    private Vector3 characterVelocityMomentum;

    private Camera fCamera;
    [SerializeField] private Camera mainCamera;
    private State state;
    private Vector3 hookshotPosition;
    private float hookshotSize;
    private CameraFov cameraFov;

    public LayerMask whatIsWall;
    public float wallrunForce, maxWallrunTime, maxWallSpeed;
    bool isWallRight, isWallLeft;
    bool isWallRunning;
    public float maxWallRunCameraTilt, wallRunCameraTilt;

    private enum State { Normal, HookshotThrown, HookshotFlyingPlayer }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        fCamera = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Camera>();
        cameraFov = mainCamera.GetComponent<CameraFov>();
        rb = GetComponent<Rigidbody>();

        state = State.Normal;
        hookshotTransform.gameObject.SetActive(false);
    }

    void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                MoveThePlayer();
                WallRunInput();
                CheckForWall();
                HandleHookshotStart();
                break;
            case State.HookshotThrown:
                MoveThePlayer();
                HandleHookshotStart();
                HandleHookShotThrown();
                break;
            case State.HookshotFlyingPlayer:
                HandleHookshotMovement();
                break;
        }

    }

    void MoveThePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();



        characterController.Move(moveDirection);

        if (characterVelocityMomentum.magnitude >= 0)
        {
            float momentumDrag = 3f;
            characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;
            if (characterVelocityMomentum.magnitude < .0f)
            {
                characterVelocityMomentum = Vector3.zero;
            }
        }
    }

    void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;

        PlayerJump();

        moveDirection.y = verticalVelocity * Time.deltaTime;

        moveDirection += characterVelocityMomentum;



    }
    void ResetGravity()
    {
        verticalVelocity = 0f;
    }

    void PlayerJump()
    {
        if ((characterController.isGrounded || isWallRunning) && TestInputDownJump())
        {
            verticalVelocity = jumpForce;
        }
    }

    private void HandleHookshotStart()
    {
        if (TestInputDownHookshot())
        {
            if (Physics.Raycast(fCamera.transform.position, fCamera.transform.forward, out RaycastHit raycastHit) && Vector3.Distance(transform.position, raycastHit.point) <= 40f && raycastHit.transform.tag == "GrapPoint")
            {
                Debug.Log(Vector3.Distance(transform.position, raycastHit.point));
                hookshotPosition = raycastHit.point;
                hookshotSize = 0f;
                hookshotTransform.gameObject.SetActive(true);
                hookshotTransform.localScale = Vector3.zero;
                state = State.HookshotThrown;
            }
        }
    }

    private void HandleHookShotThrown()
    {
        hookshotTransform.LookAt(hookshotPosition);
        float hookshotThrowSpeed = 125f;

        hookshotSize += hookshotThrowSpeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if (hookshotSize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            state = State.HookshotFlyingPlayer;
            cameraFov.SetCameraFov(HOOKSHOT_FOV);
        }
    }

    private void HandleHookshotMovement()
    {
        hookshotTransform.LookAt(hookshotPosition);
        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotMin = 10f;
        float hookshotMax = 40f;
        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotMin, hookshotMax);
        float hoookshotModifier = 5f;

        characterController.Move(hookshotDir * hookshotSpeed * hoookshotModifier * Time.deltaTime);

        float reachedHookshotDistance = 1f;

        if (Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotDistance)
        {
            StopHookshot();
        }

        if (TestInputDownHookshot())
        {
            StopHookshot();
        }
        if (TestInputDownJump())
        {
            float momentumExtraSpeed = 0.0075f;
            float jumpSpeed = 0.075f;
            characterVelocityMomentum = hookshotDir * hookshotSpeed * momentumExtraSpeed;
            characterVelocityMomentum += Vector3.up * jumpSpeed;
            StopHookshot();
        }
    }
    private void StopHookshot()
    {
        state = State.Normal;
        ResetGravity();
        hookshotTransform.gameObject.SetActive(false);
        cameraFov.SetCameraFov(NORMAL_FOV);
    }

    private bool TestInputDownHookshot()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
    public bool TestInputDownJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private void WallRunInput() //make sure to call in void Update
    {
        //Wallrun
        if (Input.GetKey(KeyCode.W) && isWallRight)
            StartWallrun();

        if (Input.GetKey(KeyCode.W) && isWallLeft)
            StartWallrun();

    }



    private void StartWallrun()
    {
        ResetGravity();
        isWallRunning = true;
        allowDashForceCounter = false;
        speed = 20;

        if (moveDirection.magnitude <= maxWallSpeed)
        {
            //Make sure char sticks to wall
            if (isWallRight)
            {
                if (TestInputDownJump())
                {
                    jumpForce = 50f;
                    ApplyGravity();
                }


                else
                {
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection = orientation.right * wallrunForce / 5 * Time.deltaTime;
                }


            }

            else
            {
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = -orientation.right * wallrunForce / 5 * Time.deltaTime;
            }

        }
    }
    private void StopWallRun()
    {
        if (isWallRunning)
        {
            jumpForce = 10;
            speed = 10;
        }

        isWallRunning = false;
        rb.useGravity = true;

    }
    private void CheckForWall() //make sure to call in void Update
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, whatIsWall);

        //leave wall run
        if (!isWallLeft && !isWallRight) StopWallRun();
        //reset double jump (if you have one :D)
        //if (isWallLeft || isWallRight) doubleJumpsLeft = startDoubleJumps;
    }
}
