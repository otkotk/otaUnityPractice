﻿using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Player : AbsCharacter
{
    // フィールド
    private int job; //職業
    public int Job { get { return this.job; } }

    private int level; //レベル
    public int Level { get { return this.level; } }

    private int thresholdExp; //経験値が閾値を超えたら、レベルアップ
    public int ThresholdExp { get { return this.thresholdExp; } set { this.thresholdExp = value; } }

    // メソッド内でインスタンス生成できるっぽい
    // コンストラクター
    public Player()
    {
        Weapon www = new Weapon();
        Name = "名無しさん";
        HP = 100;
        MP = 15;
        ATK = 5;
        DEF = 5;
        Mental = 3;
        AGI = 5;
        EXP = 0;
        BringWeapon = "w100";
        www.SelectWeapon("w100");
        WeaponAttribute = www.WeaponAttribute;
        WeaponWeakAttribute = 0;

        job = 0;
        level = 1;
        thresholdExp = 20;
        Debug.Log("主人公が呼ばれたゾ");
    }

    // メソッド
    // プレイヤーのジョブを決める
    private void PlayerJob(int job)
    {
        switch (job)
        {
            case 0:
                Console.WriteLine("無職です");
                if (thresholdExp == 20) Console.WriteLine("まだまだやなぁ");
                break;
            case 1:
                Console.WriteLine("剣士です。 HP:1.5倍 DEF:1.5倍 Mental:0.5倍");
                break;
            case 2:
                Console.WriteLine("魔法使いです。 MP:1.5倍 Mental:1.5倍 HP:0.5倍");
                break;
            case 3:
                Console.WriteLine("弓使いです。 ATK:1.5倍 AGI:1.5倍 DEF:0.5倍");
                break;
            case 4:
                Console.WriteLine("遊び人です。 AGI:2.5倍");
                break;
        }
    }

    // 経験値の管理、レベルアップ
    // ジョブによって倍率を変える
    // ステータス確認のため、タプる
    private (int, int, int, int, int, int) PlayerExpManager()
    {
        if(EXP >= thresholdExp)
        {
            level++;
            thresholdExp = level * 10;
            double _HPup = 15.0;
            double _MPup = 4.0;
            double _ATKup = 2.0;
            double _DEFup = 2.0;
            double _Mentalup = 2.0;
            double _AGIup = 2.0;

            switch (job)
            {
                // 剣士
                case 1:
                    HP += (int)(_HPup * 1.5);
                    MP += (int)_MPup;
                    ATK += (int)_ATKup;
                    DEF += (int)(_DEFup * 1.5);
                    Mental += (int)(_Mentalup * 0.5);
                    AGI += (int)_AGIup;
                    break;
                // 魔法使い
                case 2:
                    HP += (int)(_HPup *0.5);
                    MP += (int)(_MPup * 1.5);
                    ATK += (int)_ATKup;
                    DEF += (int)_DEFup;
                    Mental += (int)(_Mentalup * 1.5);
                    AGI += (int)_AGIup;
                    break;
                // 弓使い
                case 3:
                    HP += (int)_HPup;
                    MP += (int)_MPup;
                    ATK += (int)(_ATKup * 1.5);
                    DEF += (int)(_DEFup * 0.5);
                    Mental += (int)_Mentalup;
                    AGI += (int)(_AGIup * 1.5);
                    break;
                // 遊び人
                case 4:
                    HP += (int)_HPup;
                    MP += (int)_MPup;
                    ATK += (int)_ATKup;
                    DEF += (int)_DEFup;
                    Mental += (int)_Mentalup;
                    AGI += (int)(_AGIup * 2.5);
                    break;
            }
        }

        return (HP, MP, ATK, DEF, Mental, AGI);
    }
}