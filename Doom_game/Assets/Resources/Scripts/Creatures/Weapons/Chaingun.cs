using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaingun : Weapon
{
    public Chaingun()
    {
        Ammo = WeaponConfig.Instance.chaingun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.chaingun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.chaingun.minDamage;
        MaxDamage = WeaponConfig.Instance.chaingun.maxDamage;
        ShotDelay = WeaponConfig.Instance.chaingun.GetShotDelay();
        Sprite = WeaponConfig.Instance.chaingun.sprite;
    }
}
