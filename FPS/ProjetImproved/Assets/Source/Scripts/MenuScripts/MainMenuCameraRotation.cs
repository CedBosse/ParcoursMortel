using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraRotation : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
