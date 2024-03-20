using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolWeaponScript : AbstractWeapon
{
    public WeaponScriptableObject assultRifle;


    private void Awake()
    {
        StartCoroutine(WaitBeforeCalc());
    }

    private void Update()
    {
        if (Time.time >= LastTimeFired + (1 / FinalFireRate) && GotBulletsLoaded)
        {
            Fire();
            LastTimeFired = Time.time;
        }
        else if (!_currentlyReloading && !GotBulletsLoaded)
            Reload();

        if(Input.GetKey(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwapWeapon(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwapWeapon(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            SwapWeapon(3);
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            SwapWeapon(4);
        }
    }

    public  void SwapWeapon(int index)
    {
        BaseDamage = WeaponDataArray.weaponDatas[index].damage;
        BaseFireRate = WeaponDataArray.weaponDatas[index].fireRate;
        FinalMagSize = WeaponDataArray.weaponDatas[index].magazineSize;
        BaseReloadSpeed = WeaponDataArray.weaponDatas[index].reloadSpeed;
        DamageMod = WeaponDataArray.weaponDatas[index].modifier;


    }

    public override void Reload()
    {
        StartCoroutine(WaitAndReload());
    }

    private IEnumerator WaitAndReload()
    {
        _currentlyReloading = true;
        Debug.Log("Reload Started");
        yield return new WaitForSeconds(FinalReloadSpeed);
        BulletsInMag = FinalMagSize;
        _currentlyReloading = false;
    }

    private IEnumerator WaitBeforeCalc()
    {
        yield return new WaitForEndOfFrame();
        CalculateFinalAttributes();
    }
}
