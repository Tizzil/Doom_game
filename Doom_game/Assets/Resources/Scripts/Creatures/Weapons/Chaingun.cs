using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaingun : Weapon
{
    public Chaingun()
    {
        Type = WeaponType.Chaingun;
        AmmoType = WeaponConfig.Instance.chaingun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.chaingun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.chaingun.minDamage;
        MaxDamage = WeaponConfig.Instance.chaingun.maxDamage;
        ShotDelay = WeaponConfig.Instance.chaingun.GetShotDelay();
        Sprite = WeaponConfig.Instance.chaingun.sprite;
        Ammo = WeaponConfig.Instance.chaingun.ammo;
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
