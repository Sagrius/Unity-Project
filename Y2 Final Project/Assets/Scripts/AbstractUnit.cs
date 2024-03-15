using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUnit : MonoBehaviour
{
    public float _maxHP { get; protected set; }
    public float _currentHP { get; protected set; }
    public uint _armor { get; protected set; }
    public float _baseWalkSpeed { get; protected set; }
    public float _baseDamage { get; protected set; } //Only applies to enemies, base damage for player is under each gun
    public float _damageMod { get; protected set; }
    public float _baseAttackSpeed { get; protected set; } //Only applies to enemies, base attack speed for player is under each gun
    public float _attackSpeedMod { get; protected set; } //Attack speed refers to fire rate in the context of the player

    public abstract void TakeDamage(uint damage);
}
