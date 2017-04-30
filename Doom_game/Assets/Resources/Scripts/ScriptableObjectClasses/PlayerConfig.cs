using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    // singleton
    static PlayerConfig instance = null;

    public static PlayerConfig Instance
    {
        get
        {
            if (instance == null)
                instance = Resources.Load<PlayerConfig>("PlayerConfig");

            return instance;
        }
    }

    // player config
    public int MaxHP;
    public int MaxArmor;
    public float Speed;

    public int StartBullets;
    // остальные боеприпасы на старте == 0

    public int StartMoney;
}
