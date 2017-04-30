using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Internal;

namespace Internal
{
    [Serializable]
    public class WeaponInfo
    {
        public AmmoType ammoType;
        public int ammoPerShot;
        public int minDamage;
        public int maxDamage;
        public float delayPerShotSeconds;
        public Sprite sprite;

        public TimeSpan GetShotDelay()
        {
            return TimeSpan.FromSeconds(delayPerShotSeconds);
        }
    }
}

[CreateAssetMenu]
public class WeaponConfig : ScriptableObject 
{
    // singleton
    static WeaponConfig instance = null;

    public static WeaponConfig Instance
    {
        get
        {
            if (instance == null)
                instance = Resources.Load<WeaponConfig>("Configs/WeaponConfig");

            return instance;
        }
    }

    //weapons config
    public WeaponInfo pistol;
}
