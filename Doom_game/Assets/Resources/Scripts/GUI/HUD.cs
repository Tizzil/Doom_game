using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text hpText;
    public Text armorText;
    public Text moneyText;
    public Text bulletsText;
    public Text shellsText;
    public Text rocketText;
    public Text cellsText;

    public Image currentWeaponImage;

    void OnEnable()
    {
        Player.OnStartEvent += OnStart;
    }

    void OnDisable()
    {
        Player.OnStartEvent -= OnStart;
    }

    void OnStart(Player player)
    {
        hpText.text = player.HP.ToString();
        armorText.text = player.Armor.ToString();
        moneyText.text = player.Money.ToString();
        bulletsText.text = player.Ammo[AmmoType.Bullet].ToString();
        shellsText.text = player.Ammo[AmmoType.Shell].ToString();
        rocketText.text = player.Ammo[AmmoType.Rocket].ToString();
        cellsText.text = player.Ammo[AmmoType.Cell].ToString();
    }
}
