using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weaponManager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Damageable ennemyHealth;
    
    [SerializeField]
    private Animator zoomCameraAnim;
    private bool zoomed;

    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private Camera fCamera;

    private GameObject crosshair;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
       
    }

    void WeaponShoot()
    {
        if (weaponManager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit raycastHit) && raycastHit.transform.tag == "Enemy")
                {
                    ennemyHealth = raycastHit.transform.gameObject.GetComponent<Damageable>();
                    ennemyHealth.InflictDamage(5, false, this.transform.gameObject);
                }

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weaponManager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                }
                if(weaponManager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                    if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out RaycastHit raycastHit) && Vector3.Distance(transform.position, raycastHit.point) <= 20f && raycastHit.transform.tag == "Enemy")
                    {
                        ennemyHealth = raycastHit.transform.gameObject.GetComponent<Damageable>();
                        ennemyHealth.InflictDamage(20, false, this.transform.gameObject);
                    }
                }
                

                
            }

        }
    } //WeaponShoot

    void ZoomInAndOut()
    {
        if(weaponManager.GetCurrentSelectedWeapon().weaponAim == WeaponAim.AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                crosshair.SetActive(false);

            }
            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                crosshair.SetActive(true);
            }
        }
    }
}
