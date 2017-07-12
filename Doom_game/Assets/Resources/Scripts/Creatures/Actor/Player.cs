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

    public Weapon activeWeapon { get; private set; }
    public Dictionary<WeaponType, Weapon> Weapons { get; private set; }



    float speed;

    [Header("border")]

    public float xMin, xMax, yMin, yMax;

    [Space()]

    Vector2 velocity;

    public delegate void Callback();
    public static event Callback OnPlayerActivated;
    public static event Callback OnPlayerDeactivated;

    public delegate void OnStart(Player info);
    public static event OnStart OnStartEvent;

    public delegate void WeaponSwitch(Weapon weapon);
    public static event WeaponSwitch OnWeaponSwitch;

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
        activeWeapon = Weapons[WeaponType.Pistol];
        ///////////////////
        TestGiveAllWeapons();
        ///////////////////
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
        GetComponent<Rigidbody2D>().position = new Vector2
            (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, xMin, xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, yMin, yMax)
            );



        // weapon switch mouse wheel
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel > 0)
        {
            if (activeWeapon.Type == WeaponType.BGF)
            {
                SwitchWeapon(WeaponType.Pistol);
                return;
            }


            SwitchWeapon(activeWeapon.Type + 1);
        }
        else if (mouseWheel < 0)
        {
            if (activeWeapon.Type == WeaponType.Pistol)
            {
                SwitchWeapon(WeaponType.BGF);
                return;
            }

            SwitchWeapon(activeWeapon.Type - 1);
        }

        // weapon switch keys
        for (int i = (int)WeaponType.Pistol; i <= (int)WeaponType.BGF; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                SwitchWeapon((WeaponType)i);
            }
        }
    }

    void SwitchWeapon(WeaponType newWeapon)
    {
        if (Weapons[newWeapon] != null)
        {
            activeWeapon = Weapons[newWeapon];
            if (OnWeaponSwitch != null)
                OnWeaponSwitch(activeWeapon);
        }
    }



    void TestGiveAllWeapons()
    {
        Weapons[WeaponType.Pistol] = new Pistol();
        Weapons[WeaponType.Shotgun] = new Shotgun();
        Weapons[WeaponType.SuperShotgun] = new SuperShotgun();
        Weapons[WeaponType.Chaingun] = new Chaingun();
        Weapons[WeaponType.RocketLauncher] = new RocketLauncher();
        Weapons[WeaponType.Plasmagun] = new Plasmagun();
        Weapons[WeaponType.BGF] = new BFG();
    }
}
