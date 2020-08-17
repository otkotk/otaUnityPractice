using UnityEngine;
using System.Collections;
using System;

public class Rabbit : Enemies
{
    // コンストラクター
    public Rabbit()
    {
        Name = "野うさぎ";
        HP = 13;
        MP = 0;
        ATK = 2;
        DEF = 0;
        Mental = 1;
        AGI = 6;
        EXP = 4;
        BringWeapon = null;
        BringArmor = null;
        WeaponWeakAttribute = 0;
        MagicAttribute = 0;
    }
}
