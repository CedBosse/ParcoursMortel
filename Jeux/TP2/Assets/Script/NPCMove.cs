﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
            Debug.Log("Nav is broken");
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
        if (_navMeshAgent == null)
            Debug.Log("Nav is broken");
        else
            SetDestination(); SetDestination();
    }
}
