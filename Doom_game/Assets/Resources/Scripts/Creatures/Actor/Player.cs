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

    public Weapon ActiveWeapon { get; private set; }
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
        Ammo[AmmoType.Bullet] = 990; //PlayerConfig.Instance.StartBullets;
        Ammo[AmmoType.Shell] = 992;
        Ammo[AmmoType.Rocket] = 994;
        Ammo[AmmoType.Cell] = 996;

        Weapons = new Dictionary<WeaponType, Weapon>();
        for (int i = (int)WeaponType.Shotgun; i <= (int)WeaponType.BFG; i++)
        {
            Weapons[(WeaponType)i] = null;
        }
        Weapons[WeaponType.Pistol] = new Pistol();
        ActiveWeapon = Weapons[WeaponType.Pistol];
        ///////////////////
        TestGiveAllWeapons();
        ///////////////////
        if (OnStartEvent != null)
            OnStartEvent(this);
    }

    void Update()
    {
        PlayerControls();
        IsShooting();
    }

    void PlayerControls()
    {
        // movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        velocity.Set(moveHorizontal * speed, moveVertical * speed);
        GetComponent<Rigidbody2D>().velocity = velocity;


        /*GetComponent<Rigidbody2D>().position = new Vector2
            (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, xMin, xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, yMin, yMax)
            );*/



        // weapon switch mouse wheel
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel > 0)
        {
            if (ActiveWeapon.Type == WeaponType.BFG)
            {
                SwitchWeapon(WeaponType.Pistol);
                return;
            }


            SwitchWeapon(ActiveWeapon.Type + 1);
        }
        else if (mouseWheel < 0)
        {
            if (ActiveWeapon.Type == WeaponType.Pistol)
            {
                SwitchWeapon(WeaponType.BFG);
                return;
            }

            SwitchWeapon(ActiveWeapon.Type - 1);
        }

        // weapon switch keys
        for (int i = (int)WeaponType.Pistol; i <= (int)WeaponType.BFG; i++)
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
            ActiveWeapon = Weapons[newWeapon];
            if (OnWeaponSwitch != null)
                OnWeaponSwitch(ActiveWeapon);
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
        Weapons[WeaponType.BFG] = new BFG();
    }

    void IsShooting()
    {
        //float mouse = Input.GetAxis("Fire1");
        
        bool isShot = (Input.GetAxis("Fire1") > 0) ;
        
        if (isShot && ActiveWeapon.CanShot() && (Ammo[ActiveWeapon.AmmoType] >= ActiveWeapon.AmmoPerShot))
        {
            Ammo[ActiveWeapon.AmmoType] -= ActiveWeapon.AmmoPerShot;
            ActiveWeapon.Shot(shotSpawn);
        }
        else
        {
            return;
        }
    }
}
