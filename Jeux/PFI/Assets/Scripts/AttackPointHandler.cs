using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointHandler : MonoBehaviour
{
    [SerializeField] GameObject punchHitPoint;
    [SerializeField] GameObject kickHitPoint;

    void TurnOnPunch()
    {
        punchHitPoint.SetActive(true);
    }
    void TurnOffPunch()
    {
        if (punchHitPoint.activeInHierarchy)
        {
            punchHitPoint.SetActive(false);
        }
    }
    void TurnOnKick()
    {
        kickHitPoint.SetActive(true);
    }
    void TurnOffKick()
    {
        if (kickHitPoint.activeInHierarchy)
        {
            kickHitPoint.SetActive(false);
        }
    }
}
