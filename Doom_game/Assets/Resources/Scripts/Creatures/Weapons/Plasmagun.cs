using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasmagun : Weapon
{
    public Plasmagun()
    {
        Type = WeaponType.Plasmagun;
        AmmoType = WeaponConfig.Instance.plasmagun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.plasmagun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.plasmagun.minDamage;
        MaxDamage = WeaponConfig.Instance.plasmagun.maxDamage;
        ShotDelay = WeaponConfig.Instance.plasmagun.GetShotDelay();
        Sprite = WeaponConfig.Instance.plasmagun.sprite;
        Ammo = WeaponConfig.Instance.plasmagun.ammo;
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
