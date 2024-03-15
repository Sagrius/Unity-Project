using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolWeaponScript : AbstractWeapon
{
    [SerializeField] private Transform SpawnPos;

    private void OnValidate()
    {
        _baseFireRate = 2f;
        _fireRateMod = 1f;
        _baseMagSize = 12;
        _magSizeMod = 1f;
        _baseReloadSpeed = 1.2f;
        _reloadSpeedMod = 1f;
    }

    private void Awake()
    {
        StartCoroutine(WaitBeforeCalc());
    }

    private void Update()
    {
        if (Time.time >= _lastTimeFired + (1 / _finalFireRate) && _gotBulletsLoaded)
        {
            Fire();
            _lastTimeFired = Time.time;
        }
        else if (!_currentlyReloading && !_gotBulletsLoaded)
            Reload();
    }

    //Use this every time the weapon is upgraded to update the attributes
    public override void CalculateFinalAttributes()
    {
        _finalFireRate = _baseFireRate * _fireRateMod * PlayerAttributeManager.Instance._attackSpeedMod;
        _finalMagSize = _baseMagSize * _magSizeMod * PlayerAttributeManager.Instance._magSizeMod;
        _bulletsInMag = _finalMagSize;
        _finalReloadSpeed = _baseReloadSpeed * _reloadSpeedMod * PlayerAttributeManager.Instance._reloadSpeedMod;
    }

    public override void Fire()
    {
        if (_bulletsInMag >= 1)
        {//Fire
            Debug.Log("Bullet Fired");
            _bulletsInMag--;
            GameObject bullet = BulletObjectPool.Instance.GetBulletFromPool();
            bullet.SetActive(true);
            bullet.transform.position = SpawnPos.position;
            bullet.transform.rotation = SpawnPos.rotation;
        }
    }

    public override void Reload()
    {
        StartCoroutine(WaitAndReload());
    }

    private IEnumerator WaitAndReload()
    {
        _currentlyReloading = true;
        Debug.Log("Reload Started");
        yield return new WaitForSeconds(_finalReloadSpeed);
        _bulletsInMag = _finalMagSize;
        _currentlyReloading = false;
    }

    private IEnumerator WaitBeforeCalc()
    {
        yield return new WaitForEndOfFrame();
        CalculateFinalAttributes();
    }
}
