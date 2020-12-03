using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;

    [SerializeField]
    private PlayerInventory playerInventory;

    private int currentWeaponIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(3);
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (playerInventory.inventory.Contains(weapons[weaponIndex].gameObject.tag))
        {
            weapons[currentWeaponIndex].gameObject.SetActive(false);

            weapons[weaponIndex].gameObject.SetActive(true);

            currentWeaponIndex = weaponIndex;
        }
        else
        {
            return;
        }

    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        return weapons[currentWeaponIndex];
    }

}
