using UnityEngine;
using System.Collections;
using System;

public class Mouse : Enemies
{
    // コンストラクター
    public Mouse()
    {
        Name = "ヌットリア";
        HP = 18;
        MP = 0;
        ATK = 2;
        DEF = 0;
        Mental = 0;
        AGI = 8;
        EXP = 5;
        BringWeapon = null;
        BringArmor = null;
        WeaponWeakAttribute = 0;
        MagicAttribute = 0;
    }
}
