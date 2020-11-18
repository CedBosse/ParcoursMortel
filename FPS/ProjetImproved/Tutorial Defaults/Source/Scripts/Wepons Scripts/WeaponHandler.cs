using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim { NONE, SELF_AIM, AIM}

public enum WeaponFireType { SINGLE, MULTIPLE}

public enum WeaponBulletType { BULLET, NONE}

public class WeaponHandler : MonoBehaviour
{
    private Animator anim;

    public WeaponAim weaponAim;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shootSound, reloadSound;

    public WeaponFireType fireType;

    public WeaponBulletType bulletType;

    public GameObject attackPoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    /*public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }*/

    void TurnOnMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
    }
    void TurnOffMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }
    void PlayShootSound()
    {
        shootSound.Play();
    }
    void PlayReloadSound()
    {
        reloadSound.Play();
    }
    void TurnOnAttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void TurnOffAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
