using UnityEngine;
using System.Collections;
using System;

public class Slime : Enemies
{
    private int weapon;
    public int Weapon { get { return this.weapon; } set { this.weapon = value; } }

    Weapon we = new Weapon();
    // コンストラクター
    public Slime()
    {
        we.SelectWeapon("w000");
        Weapon = we.ATK;
    }

    public override int NomalAttack(Player p)
    {
        throw new System.NotImplementedException();
    }

    public override int NomalDefend()
    {
        throw new System.NotImplementedException();
    }

    public override bool RunEscape()
    {
        throw new System.NotImplementedException();
    }

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }

}
