using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    public float _baseFireRate { get; protected set; }
    public float _fireRateMod { get; protected set; }
    public float _finalFireRate { get; protected set; }
    public float _lastTimeFired { get; protected set; }
    public float _baseMagSize { get; protected set; }
    public float _magSizeMod { get; protected set; }
    public float _finalMagSize { get; protected set; }
    public float _bulletsInMag { get; protected set; }
    public bool _gotBulletsLoaded => _bulletsInMag >= 1;
    public float _baseReloadSpeed { get; protected set; }
    public float _reloadSpeedMod { get; protected set; }
    public float _finalReloadSpeed { get; protected set; }
    public bool _currentlyReloading = false;

    public abstract void Fire();
    public abstract void Reload();
    public abstract void CalculateFinalAttributes();
}
