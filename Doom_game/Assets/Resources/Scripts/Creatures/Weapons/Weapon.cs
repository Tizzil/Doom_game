using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public WeaponType Type { get; protected set; }
    public AmmoType Ammo { get; protected set; }
    public int AmmoPerShot { get; protected set; }
    
    public int MinDamage { get; protected set; }
    public int MaxDamage { get; protected set; }

    public TimeSpan ShotDelay { get; protected set; }
    public DateTime LastShotTS { get; protected set; }

    public Sprite Sprite { get; protected set; }

    public bool CanShot()
    {
        var now = DateTime.UtcNow;
        var timeFromLastShot = now.Subtract(LastShotTS);
        if (timeFromLastShot < ShotDelay)
            return false;

        return true;
    }

    public virtual void Shot()
    {
        
    }

}
