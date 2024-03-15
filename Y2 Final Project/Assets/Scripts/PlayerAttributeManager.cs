using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttributeManager : AbstractUnit
{
    public static PlayerAttributeManager Instance { get; private set; }

    public uint Score { get; private set; } = 0;
    public float WalkSpeedMod { get; private set; }
    public float ReloadSpeedMod { get; private set; } = 1f;
    public float MagSizeMod { get; private set; } = 1f;

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
    }

    private void Start()
    {
        CurrentHP = MaxHP;
    }

    public override void TakeDamage(uint damage)
    {
        CurrentHP -= (int)damage;
        Debug.Log($"Player took {damage} damage, they have {CurrentHP}HP left.");
        if (CurrentHP <= 0)
        {
            Debug.Log("Player has died");
        }
    }
}
