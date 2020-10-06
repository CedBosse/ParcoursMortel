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
        if(Vector3.Distance(player.position, transform.position) < 50)//distance bidon
        {
            animator.SetBool("isPlayerNear", true);
            Direction = (player.position - transform.position).normalized;
            transform.position += Direction * 8 * Time.deltaTime;
            transform.LookAt(player);
            //Quaternion.LookRotation(player.position, transform.position);//
        }
        else
            animator.SetBool("isPlayerNear", false);


    }


}
