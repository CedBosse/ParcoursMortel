using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weaponManager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;
    
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

       // zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
       // fCamera = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Camera>();

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
       // ZoomInAndOut();
    }

    void WeaponShoot()
    {
        if (weaponManager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                if (Physics.Raycast(fCamera.transform.position, fCamera.transform.forward, out RaycastHit raycastHit) && raycastHit.transform.tag == "Enemy")
                {
                    raycastHit.transform.gameObject.SetActive(false);
                }

                //BulletFired();
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
                    if (Physics.Raycast(fCamera.transform.position, fCamera.transform.forward, out RaycastHit raycastHit) && raycastHit.transform.tag == "Enemy")
                    {
                        raycastHit.transform.gameObject.SetActive(false);
                    }
                    //BulletFired();
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

                //zoomed = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                crosshair.SetActive(true);
            }
        }
    }
}
