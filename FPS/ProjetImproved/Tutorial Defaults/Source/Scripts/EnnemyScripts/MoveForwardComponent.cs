using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardComponent : MonoBehaviour
{
    public float force = 500;
    void Update() => transform.Translate(Vector3.forward * (force * Time.deltaTime), Space.Self);
}
