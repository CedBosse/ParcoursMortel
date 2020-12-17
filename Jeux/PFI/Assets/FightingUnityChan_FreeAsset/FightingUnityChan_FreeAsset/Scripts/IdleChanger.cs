using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animator))]

public class IdleChanger : MonoBehaviour
{

	private Animator anim;					
	private AnimatorStateInfo currentState;		
	private AnimatorStateInfo previousState;	

	void Start ()
	{
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;

	}
}
