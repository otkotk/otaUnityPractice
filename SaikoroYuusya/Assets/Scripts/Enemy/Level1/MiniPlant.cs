using UnityEngine;
using System.Collections;
using System;

public class MiniPlant : Enemies
{
    // コンストラクター
    public MiniPlant()
    {
        Name = "ミニプラント";
        HP = 10;
        MP = 0;
        ATK = 1;
        DEF = 5;
        Mental = 0;
        AGI = 1;
        EXP = 3;
        BringWeapon = null;
        BringArmor = null;
        WeaponWeakAttribute = 0;
        MagicAttribute = 0;
    }

    // Enemiesの行動を選択する
    // 序盤は攻撃しかしない。
    // Playerの行動の後にコルーチンで最初に呼ばれる。
    // Enemiesの処理が終わった後に、テキストなどを表示する。
    // 例:30のダメージを与えた
    public void SelectAction()
    {
        System.Random random = new System.Random();

    }
}
