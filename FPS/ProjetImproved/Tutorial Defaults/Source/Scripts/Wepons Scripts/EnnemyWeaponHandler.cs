using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWeaponHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shootSound;
    void TurnOnEnnemyMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
    }
    void TurnOffEnnemyMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }
}
