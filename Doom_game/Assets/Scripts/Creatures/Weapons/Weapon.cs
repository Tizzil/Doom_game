using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon{

    public Sprite image;

    public int damage = 0;
    public float fireRate = 0f;
    public float nextfire = 0f;

    //public static string cur_weapon = null;

    public static string PISTOL = "PISTOL";
    public static string SHOTGUN = "SHOTGUN";
    public static string SHOTGUN2 = "SHOTGUN2";
    public static string CHAINGUN = "CHAINGUN";
    public static string ROCKET = "ROCKET";
    public static string PLASMAGUN = "PLASMAGUN";
    public static string BFG = "BFG";

    static void Main(string[] args)
    {
        LinkedList<string> weapon = new LinkedList<string>();
        weapon.AddLast(PISTOL);
        weapon.AddLast(SHOTGUN);
        weapon.AddLast(SHOTGUN2);
        weapon.AddLast(CHAINGUN);
        weapon.AddLast(ROCKET);
        weapon.AddLast(PLASMAGUN);
        weapon.AddLast(BFG);
    }

    public void Shot()
    {

    }
}
