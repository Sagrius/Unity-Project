using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAttributesManager : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _pistolAmmoBar;
    [SerializeField] private PistolWeaponScript _pistol;

    private void LateUpdate()
    {
        if (PlayerAttributeManager.Instance != null)
        {
            _healthBar.fillAmount = PlayerAttributeManager.Instance.CurrentHP / PlayerAttributeManager.Instance.MaxHP;
        }

        if (_pistol != null)
        {
            _pistolAmmoBar.fillAmount = _pistol.BulletsInMag / _pistol.FinalMagSize;
        }
    }
}