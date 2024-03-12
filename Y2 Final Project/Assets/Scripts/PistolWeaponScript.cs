using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolWeaponScript : MonoBehaviour
{
    public static PistolWeaponScript instance { get; private set; }

    [SerializeField] private float BaseFireRate = 2f; //Remove serialize after testing is done
    public float FireRateMod { get; private set; } = 1f;
    public float FinalFireRate { get; private set; }
    private float lastTimeFired;
    public uint BaseMagSize { get; private set; } = 12;
    public float MagSizeMod { get; private set; } = 1f;
    public uint FinalMagSize { get; private set; }
    private uint BulletsInMag;
    private bool GotBulletsLoaded => BulletsInMag >= 1;
    public float BaseReloadSpeed { get; private set; } = 1.2f;
    public float ReloadSpeedMod { get; private set; } = 1f;
    public float FinalReloadSpeed { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        StartCoroutine(WaitAndCalcAttributes());
    }

    private void FixedUpdate()
    {
        if (Time.time >= lastTimeFired + (1/FinalFireRate) && GotBulletsLoaded)
        {
            if (TryFireBullet())
                lastTimeFired = Time.time;
            else
                StartCoroutine(WaitAndReload());
        }
    }

    private void CalculateFinalAttributes()
    {
        FinalFireRate = (float)(BaseFireRate * FireRateMod * PlayerAttributeManager.instance.PlayerFireRateMod);
        FinalMagSize = (uint)(BaseMagSize * MagSizeMod * PlayerAttributeManager.instance.PlayerMagSizeMod);
        BulletsInMag = FinalMagSize;
        FinalReloadSpeed = (float)(BaseReloadSpeed * ReloadSpeedMod * PlayerAttributeManager.instance.PlayerReloadSpeedMod);
    }

    private bool TryFireBullet()
    {
        if (BulletsInMag >= 1)
        {//Fire
            BulletsInMag--;
            return true;
        }
        else return false;
    }

    private IEnumerator WaitAndCalcAttributes()
    {
        yield return new WaitForEndOfFrame();
        CalculateFinalAttributes();
    }
    private IEnumerator WaitAndReload()
    {
        yield return new WaitForSeconds(FinalReloadSpeed);
        BulletsInMag = FinalMagSize;
    }
}
