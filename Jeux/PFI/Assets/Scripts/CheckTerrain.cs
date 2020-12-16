using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrain : MonoBehaviour
{
    [SerializeField] private LayerMask trampoline;
    private bool isTouchingTrampoline;

    public Transform orientation;
    [SerializeField] Rigidbody rb;
    public float trampolineForce = 100;


    // Update is called once per frame
    void Update()
    {
        TrampolineJump();
    }
    void TrampolineJump()
    {
        isTouchingTrampoline = Physics.Raycast(transform.position, -orientation.up, 1f, trampoline);

        if (isTouchingTrampoline)
        {

            rb.AddForce(0, trampolineForce, 0);
        }
    }
}
