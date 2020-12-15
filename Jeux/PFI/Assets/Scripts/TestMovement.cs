using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 2f;
    [SerializeField] private Rigidbody rb;
    private int jumpCounter = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TestInput();
        Jump();
    }
    void TestInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 0.005f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 90, transform.eulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 0.005f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, -90, transform.eulerAngles.z);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCounter < 2)
            {
                Debug.Log("YO");
                rb.AddForce(jumpForce * Vector3.up);
                jumpCounter++;
            }
            else
            {
                jumpCounter = 0;
            }

        }
    }

}
