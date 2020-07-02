using UnityEngine;
using System.Collections;
using System;

public class Slime : Enemies
{
    private int weaponPlusAttack;
    public int WeaponPlusAttack { get { return this.weaponPlusAttack; } set { this.weaponPlusAttack = value; } }

    private string bringWeapon = null;
    public string BringWeapon { get { return this.bringWeapon; } }

    Weapon we = new Weapon();
    // コンストラクター
    public Slime()
    {
        we.SelectWeapon(bringWeapon);
        weaponPlusAttack = we.ATK;
    }
}
