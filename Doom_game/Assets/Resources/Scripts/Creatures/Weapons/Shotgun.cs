using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public Shotgun()
    {
        Type = WeaponType.Shotgun;
        Ammo = WeaponConfig.Instance.shotgun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.shotgun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.shotgun.minDamage;
        MaxDamage = WeaponConfig.Instance.shotgun.maxDamage;
        ShotDelay = WeaponConfig.Instance.shotgun.GetShotDelay();
        Sprite = WeaponConfig.Instance.shotgun.sprite;
    }
}
