using UnityEngine;
using System.Collections;
using System;

public class Slime : Enemies
{
    private int weaponPlusAttack;
    public int WeaponPlusAttack { get { return this.weaponPlusAttack; } set { this.weaponPlusAttack = value; } }

    private string bringWeapon = "w000";
    public string BringWeapon { get { return this.bringWeapon; } }

    Weapon we = new Weapon();
    // コンストラクター
    public Slime()
    {
        we.SelectWeapon(bringWeapon);
        weaponPlusAttack = we.ATK;
    }

    public override int NomalAttack(Player p)
    {
        throw new System.NotImplementedException();
    }

    public override int NomalDefend(Player p)
    {
        throw new System.NotImplementedException();
    }

    public override bool RunEscape(Player p)
    {
        throw new System.NotImplementedException();
    }

    public override void UseItem(Player p)
    {
        throw new System.NotImplementedException();
    }

}
