using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolWeaponScript : AbstractWeapon
{
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
