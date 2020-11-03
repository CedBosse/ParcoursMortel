using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MouseLook : MonoBehaviour
{    
    [SerializeField]
    private Transform playerRoot, lookRoot;
    private PlayerMovement playerMov;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool canUnlock = true;

    [SerializeField]
    private float sensitivity = 5f;

    [SerializeField]
    private int smoothSteps = 10;

    [SerializeField]
    private float smoothWeight = 0.4f;

    [SerializeField]
    private float roll_Angle = 10f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private Vector2 defaultLookLimits = new Vector2(-70f, 80f);

    private Vector2 lookAngles;
    private Vector2 currentMouseLook;
    private Vector2 smoothMove;

    private float currentRollAngle;

    private int lastLookFrame;

    private void Awake()
    {
        playerMov = GetComponentInParent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LockAndUnlockCursor();

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }

    void LockAndUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void LookAround()
    {
        currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        lookAngles.x += currentMouseLook.x * sensitivity * (invert ? 1f : -1f);
        lookAngles.y += currentMouseLook.y * sensitivity;

        lookAngles.x = Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

        currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * roll_Angle, Time.deltaTime * roll_Speed);

        lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, currentRollAngle);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);


        //While Wallrunning
        //Tilts camera in .5 second
        if (Mathf.Abs(currentRollAngle) < 25 && playerMov.isWallRunning && playerMov.isWallRight)
            currentRollAngle += Time.deltaTime * 25 * 2;
        if (Mathf.Abs(currentRollAngle) < 25 && playerMov.isWallRunning && playerMov.isWallLeft)
            currentRollAngle -= Time.deltaTime * 25 * 2;

        //Tilts camera back again
        if (currentRollAngle > 0 && !playerMov.isWallRight && !playerMov.isWallLeft)
            currentRollAngle -= Time.deltaTime * 25 * 2;
        if (currentRollAngle < 0 && !playerMov.isWallRight && !playerMov.isWallLeft)
            currentRollAngle += Time.deltaTime * 25 * 2;
    }
}
