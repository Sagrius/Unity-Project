using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttributeManager : MonoBehaviour
{
    public static PlayerAttributeManager Instance { get; private set; }

    public uint Score { get; private set; } = 0;
    public float MaxHP { get; private set; } = 100;
    public float CurrentHP { get; private set; } = 100;
    public float PlayerWalkSpeedMod { get; private set; }
    public uint PlayerDamageMod { get; private set; }
    public uint PlayerReloadSpeedMod { get; private set; } = 1;
    public uint PlayerFireRateMod { get; private set; } = 1;
    public float PlayerMagSizeMod { get; private set; } = 1f;
    public uint PlayerArmorValue { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        StartCoroutine(Test());
    }

    private void TakeDamage(uint damage)
    {
        CurrentHP -= (int)damage;
        Debug.Log($"Player took {damage} damage, they have {CurrentHP}HP left.");
        if (CurrentHP <= 0)
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
