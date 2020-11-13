using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
            UnityEngine.Debug.Log("Nav is broken");
        else
            SetDestination();
    }

    private void SetDestination()
    {
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }


    // Update is called once per frame
    void Update()
    {
       // Debug.Log(_navMeshAgent.isOnOffMeshLink);
        if (_navMeshAgent == null)
            UnityEngine.Debug.Log("Nav is broken");
        else
            SetDestination(); SetDestination();

        if (_navMeshAgent.isOnOffMeshLink)
            _animator.SetBool("isJumping", true);
        else
            _animator.SetBool("isJumping", false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }
}