using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolWeaponScript : MonoBehaviour
{
    public static PistolWeaponScript Instance { get; private set; }

    [SerializeField] private Transform SpawnPos;
    [SerializeField] private float BaseFireRate = 2f; //Remove serialize after testing is done
    public float FireRateMod { get; private set; } = 1f;
    public float FinalFireRate { get; private set; }
    private float lastTimeFired;
    public float BaseMagSize { get; private set; } = 12;
    public float MagSizeMod { get; private set; } = 1f;
    public float FinalMagSize { get; private set; }
    public float BulletsInMag { get; private set; }
    private bool GotBulletsLoaded => BulletsInMag >= 1;
    public float BaseReloadSpeed { get; private set; } = 1.2f;
    public float ReloadSpeedMod { get; private set; } = 1f;
    public float FinalReloadSpeed { get; private set; }
    private bool currentlyReloading = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        StartCoroutine(WaitBeforeCalc());
    }

    private void FixedUpdate()
    {
        if (Time.time >= lastTimeFired + (1/FinalFireRate) && GotBulletsLoaded)
        {
            FireBullet();
            lastTimeFired = Time.time;
        }
        else if (!currentlyReloading && !GotBulletsLoaded)
            StartCoroutine(WaitAndReload());
    }

    //Use this every time the weapon is upgraded to update the attributes
    private void CalculateFinalAttributes()
    {
        FinalFireRate = BaseFireRate * FireRateMod * PlayerAttributeManager.Instance.PlayerFireRateMod;
        FinalMagSize = BaseMagSize * MagSizeMod * PlayerAttributeManager.Instance.PlayerMagSizeMod;
        BulletsInMag = FinalMagSize;
        FinalReloadSpeed = BaseReloadSpeed * ReloadSpeedMod * PlayerAttributeManager.Instance.PlayerReloadSpeedMod;
    }

    private void FireBullet()
    {
        if (BulletsInMag >= 1)
        {//Fire
            Debug.Log("Bullet Fired");
            BulletsInMag--;
            GameObject bullet = BulletObjectPool.Instance.GetBulletFromPool();
            bullet.SetActive(true);
            bullet.transform.position = SpawnPos.position;
            bullet.transform.rotation = SpawnPos.rotation;
        }
    }

    private IEnumerator WaitAndReload()
    {
        currentlyReloading = true;
        Debug.Log("Reload Started");
        yield return new WaitForSeconds(FinalReloadSpeed);
        BulletsInMag = FinalMagSize;
        currentlyReloading = false;
    }

    private IEnumerator WaitBeforeCalc()
    {
        yield return new WaitForEndOfFrame();
        CalculateFinalAttributes();
    }
}
