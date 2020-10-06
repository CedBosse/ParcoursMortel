using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Quaternion camRotation;
    public float camSensitivity = 5;
    public float lookUpMax = 60;
    public float lookUpMin = -60;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        camRotation.x += Input.GetAxis("Mouse Y") * camSensitivity * (-1);
        camRotation.y += Input.GetAxis("Mouse X") * camSensitivity;

        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
