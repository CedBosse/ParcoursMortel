using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charact))]
[RequireComponent(typeof(CharacterMovement))]
public class PInput : MonoBehaviour
{
    private Charact character;
    private CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Charact>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        character.AddMovementInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));       

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            character.ToggleRun();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.Jump();
        }
    }
}
