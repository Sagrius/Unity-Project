using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUnit : MonoBehaviour
{
    [field: SerializeField] public float MaxHP { get; protected set; }
    [field: SerializeField] public float DamageMod { get; protected set; }
    [field: SerializeField] public float AttackSpeedMod { get; protected set; } //Attack speed refers to fire rate in the context of the player
    public float CurrentHP { get; protected set; }
    public uint Armor { get; protected set; } = 0;
    public float BaseWalkSpeed { get; protected set; }
    public float BaseDamage { get; protected set; } //Only applies to enemies, base damage for player is under each gun
    public float BaseAttackSpeed { get; protected set; } //Only applies to enemies, base attack speed for player is under each gun

    public abstract void TakeDamage(uint damage);
}
