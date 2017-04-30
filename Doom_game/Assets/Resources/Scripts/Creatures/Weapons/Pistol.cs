using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public Pistol()
    {
        Ammo = WeaponConfig.Instance.pistol.ammoType;
        AmmoPerShot = WeaponConfig.Instance.pistol.ammoPerShot;
        MinDamage = WeaponConfig.Instance.pistol.minDamage;
        MaxDamage = WeaponConfig.Instance.pistol.maxDamage;
        ShotDelay = WeaponConfig.Instance.pistol.GetShotDelay();
        Sprite = WeaponConfig.Instance.pistol.sprite;
    }

    public override void Shot()
    {
        base.Shot();

    }
}
