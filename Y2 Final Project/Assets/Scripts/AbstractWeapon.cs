using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    protected bool _currentlyReloading = false;

    #region properties
    public float BulletsInMag { get;  set; }
    public float FinalMagSize { get;  set; }

    #region seriealizedProperies
    [field: SerializeField] protected Transform BulletSpawnPoint { get;  set; }
    [field: SerializeField] protected float BaseFireRate { get;  set; }
    [field: SerializeField] protected float FireRateMod { get;  set; }
    [field: SerializeField] protected float MagSizeMod { get;  set; }
    [field: SerializeField] protected float BaseReloadSpeed { get;  set; }
    [field: SerializeField] protected float BaseMagSize { get;  set; }
    [field: SerializeField] protected float ReloadSpeedMod { get;  set; }
    #endregion

    protected float FinalFireRate { get;  set; }
    protected bool GotBulletsLoaded => BulletsInMag >= 1;
    protected float FinalReloadSpeed { get; set; }
    protected float LastTimeFired { get; set; }
    #endregion

    public abstract void Reload();

    //Use this every time the weapon is upgraded to update the attributes
    public virtual void CalculateFinalAttributes()
    {
        FinalFireRate = BaseFireRate * FireRateMod * PlayerAttributeManager.Instance.AttackSpeedMod;
        FinalMagSize = Mathf.Max((BaseMagSize * MagSizeMod * PlayerAttributeManager.Instance.MagSizeMod), 1);
        BulletsInMag = FinalMagSize;
        FinalReloadSpeed = BaseReloadSpeed * ReloadSpeedMod * PlayerAttributeManager.Instance.ReloadSpeedMod;
    }

    public virtual void Fire()
    {
        if (BulletsInMag >= 1)
        {//Fire
            Debug.Log("Bullet Fired");
            BulletsInMag--;
            GameObject bullet = BulletObjectPool.Instance.GetBulletFromPool();
            bullet.SetActive(true);
            bullet.transform.position = BulletSpawnPoint.position;
            bullet.transform.rotation = BulletSpawnPoint.rotation;
        }
    }
}
