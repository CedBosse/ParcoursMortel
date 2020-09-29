using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 velocity;
    public Transform t_mesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * 0.1f);

        if(velocity.magnitude > 0)
        {
            t_mesh.rotation = Quaternion.LookRotation(velocity);
        }
    }
    
    public Vector3 Velocity { get => velocity; set => velocity = value; }
}
