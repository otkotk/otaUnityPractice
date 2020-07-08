using UnityEngine;
using System.Collections;
using System;

public class Thief : Enemies
{
    // コンストラクター
    public Thief()
    {
        Name = "盗賊";
        HP = 21;
        MP = 0;
        ATK = 4;
        DEF = 2;
        Mental = 1;
        AGI = 4;
        EXP = 8;
        BringWeapon = null;
        BringArmor = null;
        WeaponWeakAttribute = 0;
        MagicAttribute = 0;
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
