using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    private float time;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Vector3.Distance(player.position, transform.position) < 50)//distance bidon
        {
            transform.LookAt(player);
            if (time >= 1)
            {           
                animator.SetBool("isShooting", true);
                //shoot for real
                time = 0;
            }          
            else
                animator.SetBool("isShooting", false);
        }
    }
}
