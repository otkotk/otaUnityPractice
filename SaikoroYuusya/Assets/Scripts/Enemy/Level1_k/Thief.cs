﻿using UnityEngine;
using System.Collections;
using System;

public class Thief : Enemies
{
    // コンストラクター
    public Thief()
    {
        Name = "盗賊";
        HP = 50;
        MP = 0;
        ATK = 4;
        DEF = 2;
        Mental = 1;
        AGI = 4;
        EXP = 26;
        BringWeapon = "w100";
        BringArmor = null;
        WeaponWeakAttribute = 0;
        MagicAttribute = 0;
    }
}
