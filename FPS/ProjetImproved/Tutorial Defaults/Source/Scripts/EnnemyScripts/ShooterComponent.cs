using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    private float time;
    private ProjectileShooterComponent gun;
    private Transform target;


    void Awake()
    {
        gun = GameObject.FindGameObjectsWithTag("Weapon")[0].GetComponent<ProjectileShooterComponent>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {      
        time += Time.deltaTime;
        if (Vector3.Distance(player.position, transform.position) < 50)
        {
            var rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * time);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            if (time >= 1)
            {
                animator.SetBool("isShooting", true);
                gun.Shoot();
                //shoot for real
                time = 0;
            }          
            else
                animator.SetBool("isShooting", false);
        }
        else
            animator.SetBool("isShooting", false);
    }
}
