using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShotgun : Weapon
{
    public SuperShotgun()
    {
        Type = WeaponType.SuperShotgun;
        Ammo = WeaponConfig.Instance.superShotgun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.superShotgun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.superShotgun.minDamage;
        MaxDamage = WeaponConfig.Instance.superShotgun.maxDamage;
        ShotDelay = WeaponConfig.Instance.superShotgun.GetShotDelay();
        Sprite = WeaponConfig.Instance.superShotgun.sprite;
    }
}
