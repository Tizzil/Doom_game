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

    public Weapon weapon;
    public Weapon active_weapon;

    public float PL_speed;
    public int PL_hp;
    public int PL_armor;
    public int PL_bull;
    public int PL_shel;
    public int PL_rckt;
    public int PL_plsm;

    Vector2 velocity;

    public delegate void Callback();
    public static event Callback OnPlayerActivated;
    public static event Callback OnPlayerDeactivated;

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
    }



    private void Update()
    {
        PlayerControls();
    }

    void PlayerControls()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        velocity.Set(moveHorizontal * PL_speed, moveVertical * PL_speed);
        GetComponent<Rigidbody2D>().velocity = velocity;

    }

    public void ChangeWeapon(string cur_W)
    {
        if (Input.GetButton("Mouse ScrollWheel"))
        {

        }
    }


}
