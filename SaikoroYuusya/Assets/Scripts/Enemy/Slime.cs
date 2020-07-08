using UnityEngine;
using System.Collections;
using System;

public class Slime : Enemies
{
    // コンストラクター
    public Slime()
    {
        Weapon www = new Weapon();
        www.SelectWeapon(BringWeapon);
        WeaponAttribute = www.WeaponAttribute;
        HP = 100;
        MP = 10;
        ATK = 3;
        DEF = 1;
        Mental = 1;
        AGI = 1;
        EXP = 5;
        Debug.Log("スライムが呼ばれたよぉ");
    }

    public void NomalAttackAccept(int damage)
    {
        HP -= damage;
    }

    public override void TestText()
    {
        Debug.Log("スライムです＾＾");
    }
}
