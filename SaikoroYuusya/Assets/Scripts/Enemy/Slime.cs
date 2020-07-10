using UnityEngine;
using System.Collections;
using System;

public class Slime : Enemies
{
    // コンストラクター
    public Slime()
    {
        Name = "スライム";
        HP = 15;
        MP = 0;
        ATK = 1;
        DEF = 0;
        Mental = 0;
        AGI = 1;
        EXP = 3;
        BringWeapon = null;
        BringArmor = null;
        WeaponWeakAttribute = 0;
        MagicAttribute = 2;
    }

    // こうげき


    // ぼうぎょ
    public void Defend()
    {

    }
}
