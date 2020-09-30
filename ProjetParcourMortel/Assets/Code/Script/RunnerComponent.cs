using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerComponent : MonoBehaviour
{
    private Transform player;
    private Vector3 Direction;
    private Animator animator;
    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < 10)//distance bidon
        {
            animator.SetBool("isPlayerNear", true);
            Direction = (player.position - transform.position).normalized;
            transform.position += Direction * 50 * Time.deltaTime;
        }
        else
            animator.SetBool("isPlayerNear", false);


    }


}
