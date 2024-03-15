using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttributeManager : AbstractUnit
{
    public static PlayerAttributeManager Instance { get; private set; }

    public uint _score { get; private set; } = 0;
    public float _walkSpeedMod { get; private set; }
    public float _reloadSpeedMod { get; private set; } = 1f;
    public float _magSizeMod { get; private set; } = 1f;

    private void OnValidate()
    {
        _maxHP = 100;
        _currentHP = _maxHP;
        _damageMod = 1f;
        _attackSpeedMod = 1f;
        _armor = 0;
    }

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
        StartCoroutine(Test());
    }

    public override void TakeDamage(uint damage)
    {
        _currentHP -= (int)damage;
        Debug.Log($"Player took {damage} damage, they have {_currentHP}HP left.");
        if (_currentHP <= 0)
        {
            Debug.Log("Player has died");
        }
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        TakeDamage(5);
    }
}
