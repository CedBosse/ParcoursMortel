using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Character))]

public class PlayerInput : MonoBehaviour
{
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        
    }

    // Update is called once per frame
    void Update()
    {
        character.AddMovementInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            character.ToggleRun();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.Jump();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            character.Swing();
        }
    }
}
