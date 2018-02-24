using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public Pistol()
    {
        Type = WeaponType.Pistol;
        AmmoType = WeaponConfig.Instance.pistol.ammoType;
        AmmoPerShot = WeaponConfig.Instance.pistol.ammoPerShot;
        MinDamage = WeaponConfig.Instance.pistol.minDamage;
        MaxDamage = WeaponConfig.Instance.pistol.maxDamage;
        ShotDelay = WeaponConfig.Instance.pistol.GetShotDelay();
        Sprite = WeaponConfig.Instance.pistol.sprite;
        Ammo = WeaponConfig.Instance.pistol.ammo;
    }

    override public void Shot(Transform _shotspawn)
    {
        GameObject newbullet = GameObject.Instantiate(Ammo, _shotspawn.position, Quaternion.identity) as GameObject;

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - newbullet.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        newbullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
