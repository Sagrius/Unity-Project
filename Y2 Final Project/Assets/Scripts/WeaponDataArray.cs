using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataArray : MonoBehaviour
{
    public static WeaponDataArray Instance { get; private set; }

   [SerializeField] public static WeaponScriptableObject[] weaponDatas;
    public WeaponScriptableObject[] publicWeaponDatas;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        weaponDatas = publicWeaponDatas;
    }
}
