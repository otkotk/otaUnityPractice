using UnityEngine;
using System.Collections;
using System;

public class Goblin : Enemies
{
    // コンストラクター
    public Goblin()
    {
        Name = "コブリン";
        HP = 27;
        MP = 0;
        ATK = 2;
        DEF = 0;
        Mental = 1;
        AGI = 2;
        EXP = 5;
        BringWeapon = null;
        BringArmor = null;
        WeaponWeakAttribute = 0;
        MagicAttribute = 0;
    }
}
