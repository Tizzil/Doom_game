using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public Shotgun()
    {
        Type = WeaponType.Shotgun;
        AmmoType = WeaponConfig.Instance.shotgun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.shotgun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.shotgun.minDamage;
        MaxDamage = WeaponConfig.Instance.shotgun.maxDamage;
        ShotDelay = WeaponConfig.Instance.shotgun.GetShotDelay();
        Sprite = WeaponConfig.Instance.shotgun.sprite;
        Ammo = WeaponConfig.Instance.shotgun.ammo;
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
