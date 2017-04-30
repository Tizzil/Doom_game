using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[System.Serializable]
public class Weapon
{
    public Sprite image;

    
    public int damage = 0;

    public static string PISTOL     = "PISTOL";
	public static string SHOTGUN    = "SHOTGUN";
	public static string SHOTGUN2   = "SHOTGUN2";
	public static string CHAINGUN   = "CHAINGUN";
	public static string ROCKET     = "ROCKET";
	public static string PLASMAGUN  = "PLASMAGUN";
	public static string BFG1       = "BFG1";
}
*/
public class Player : MonoBehaviour
{
    public Transform shotSpawn;

    public int HP { get; private set; }
    public int Armor { get; private set; }
    public int Money { get; private set; }
    public Dictionary<AmmoType, int> Ammo { get; private set; }

    public Dictionary<WeaponType, Weapon> Weapons { get; private set; } 

    Weapon active_weapon;

    float speed;
    Vector2 velocity;

    public delegate void Callback();
    public static event Callback OnPlayerActivated;
    public static event Callback OnPlayerDeactivated;

    public delegate void OnStart(Player info);
    public static event OnStart OnStartEvent;

    void OnEnable()
    {
        if (OnPlayerActivated != null)
            OnPlayerActivated();
    }

    void OnDisable()
    {
        if (OnPlayerDeactivated != null)
            OnPlayerDeactivated();
    }

    public void Start()
    {
        velocity = new Vector2();
        HP = PlayerConfig.Instance.MaxHP;
        Armor = PlayerConfig.Instance.StartArmor;
        Money = PlayerConfig.Instance.StartMoney;
        speed = PlayerConfig.Instance.Speed;

        Ammo = new Dictionary<AmmoType, int>();
        Ammo[AmmoType.Bullet] = PlayerConfig.Instance.StartBullets;
        Ammo[AmmoType.Shell] = 0;
        Ammo[AmmoType.Rocket] = 0;
        Ammo[AmmoType.Cell] = 0;

        Weapons = new Dictionary<WeaponType, Weapon>();
        for (int i = (int)WeaponType.Shotgun; i <= (int)WeaponType.BGF; i++)
        {
            Weapons[(WeaponType)i] = null;
        }
        Weapons[WeaponType.Pistol] = new Pistol();

        if (OnStartEvent != null)
            OnStartEvent(this);
    }

    void Update()
    {
        PlayerControls();
    }

    void PlayerControls()
    {
        // movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        velocity.Set(moveHorizontal * speed, moveVertical * speed);
        GetComponent<Rigidbody2D>().velocity = velocity;
    }




}
