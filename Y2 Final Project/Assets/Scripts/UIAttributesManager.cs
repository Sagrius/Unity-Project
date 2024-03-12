using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAttributesManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image pistolAmmoBar;

    private void LateUpdate()
    {
        if (PlayerAttributeManager.Instance != null)
        {
            healthBar.fillAmount = PlayerAttributeManager.Instance.CurrentHP / PlayerAttributeManager.Instance.MaxHP;
        }

        if (PistolWeaponScript.Instance != null)
        {
            pistolAmmoBar.fillAmount = PistolWeaponScript.Instance.BulletsInMag / PistolWeaponScript.Instance.FinalMagSize;
        }
    }
}