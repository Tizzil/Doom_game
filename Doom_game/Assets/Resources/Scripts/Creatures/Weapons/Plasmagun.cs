using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasmagun : Weapon
{
    public Plasmagun()
    {
        Ammo = WeaponConfig.Instance.plasmagun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.plasmagun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.plasmagun.minDamage;
        MaxDamage = WeaponConfig.Instance.plasmagun.maxDamage;
        ShotDelay = WeaponConfig.Instance.plasmagun.GetShotDelay();
        Sprite = WeaponConfig.Instance.plasmagun.sprite;
    }
}
