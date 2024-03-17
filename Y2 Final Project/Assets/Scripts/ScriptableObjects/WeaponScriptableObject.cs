using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data",
    menuName = "Tools/Weapon Data", order = 0)]
public class WeaponScriptableObject : ScriptableObject
{
    // public uint Damage => fireDamage;
    //
    // [Header("Damage")]
    // [SerializeField] private uint fireDamage;
    [SerializeField] public float fireRate;
    [SerializeField] public float damage;
    [SerializeField] public float magazineSize;
    [SerializeField] public float reloadSpeed;
    [SerializeField] public float maxRange;
    [SerializeField] public float modifier;


}

