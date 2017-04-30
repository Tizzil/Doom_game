using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFG : Weapon
{
    public BFG()
    {
        Type = WeaponType.BGF;
        Ammo = WeaponConfig.Instance.bfg.ammoType;
        AmmoPerShot = WeaponConfig.Instance.bfg.ammoPerShot;
        MinDamage = WeaponConfig.Instance.bfg.minDamage;
        MaxDamage = WeaponConfig.Instance.bfg.maxDamage;
        ShotDelay = WeaponConfig.Instance.bfg.GetShotDelay();
        Sprite = WeaponConfig.Instance.bfg.sprite;
    }
}
