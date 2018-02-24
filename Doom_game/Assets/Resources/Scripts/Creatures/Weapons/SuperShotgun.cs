using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShotgun : Weapon
{
    public SuperShotgun()
    {
        Type = WeaponType.SuperShotgun;
        AmmoType = WeaponConfig.Instance.superShotgun.ammoType;
        AmmoPerShot = WeaponConfig.Instance.superShotgun.ammoPerShot;
        MinDamage = WeaponConfig.Instance.superShotgun.minDamage;
        MaxDamage = WeaponConfig.Instance.superShotgun.maxDamage;
        ShotDelay = WeaponConfig.Instance.superShotgun.GetShotDelay();
        Sprite = WeaponConfig.Instance.superShotgun.sprite;
        Ammo = WeaponConfig.Instance.superShotgun.ammo;
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
