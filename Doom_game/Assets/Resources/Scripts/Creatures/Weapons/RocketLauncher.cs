using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public RocketLauncher()
    {
        Type = WeaponType.RocketLauncher;
        AmmoType = WeaponConfig.Instance.rocket.ammoType;
        AmmoPerShot = WeaponConfig.Instance.rocket.ammoPerShot;
        MinDamage = WeaponConfig.Instance.rocket.minDamage;
        MaxDamage = WeaponConfig.Instance.rocket.maxDamage;
        ShotDelay = WeaponConfig.Instance.rocket.GetShotDelay();
        Sprite = WeaponConfig.Instance.rocket.sprite;
        Ammo = WeaponConfig.Instance.rocket.ammo;
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
