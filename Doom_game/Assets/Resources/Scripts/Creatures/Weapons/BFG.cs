using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFG : Weapon
{
    public BFG()
    {
        Type = WeaponType.BFG;
        AmmoType = WeaponConfig.Instance.bfg.ammoType;
        AmmoPerShot = WeaponConfig.Instance.bfg.ammoPerShot;
        MinDamage = WeaponConfig.Instance.bfg.minDamage;
        MaxDamage = WeaponConfig.Instance.bfg.maxDamage;
        ShotDelay = WeaponConfig.Instance.bfg.GetShotDelay();
        Sprite = WeaponConfig.Instance.bfg.sprite;
        Ammo = WeaponConfig.Instance.bfg.ammo;
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
