using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public RocketLauncher()
    {
        Ammo = WeaponConfig.Instance.rocket.ammoType;
        AmmoPerShot = WeaponConfig.Instance.rocket.ammoPerShot;
        MinDamage = WeaponConfig.Instance.rocket.minDamage;
        MaxDamage = WeaponConfig.Instance.rocket.maxDamage;
        ShotDelay = WeaponConfig.Instance.rocket.GetShotDelay();
        Sprite = WeaponConfig.Instance.rocket.sprite;
    }
}
