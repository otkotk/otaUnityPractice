using UnityEngine;
using System.Collections;
using System;

public class Slime : Enemies
{
    private int weaponAttribute;
    public int WeaponPlusAttack { get { return this.weaponAttribute; } set { this.weaponAttribute = value; } }

    private string bringWeapon = "w000";
    public string BringWeapon { get { return this.bringWeapon; } }

    // コンストラクター
    public Slime()
    {
        Weapon www = new Weapon();
        www.SelectWeapon(bringWeapon);
        weaponAttribute = www.WeaponAttribute;
        HP = 100;
        MP = 10;
        ATK = 3;
        DEF = 1;
        Mental = 1;
        AGI = 1;
        EXP = 5;
    }

    public void NomalAttackAccept(int damage)
    {
        HP -= damage;
    }
}
