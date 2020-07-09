using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Player : AbsCharacter, IBattleCommand
{
    // フィールド
    private int job; //職業
    public int Job { get { return this.job; } set { this.job = value; } }

    private int level; //レベル
    public int Level { get { return this.level; } set { this.level = value; } }

    private int thresholdExp; //経験値が閾値を超えたら、レベルアップ
    public int ThresholdExp { get { return this.thresholdExp; } set { this.thresholdExp = value; } }

    // メソッド内でインスタンス生成できるっぽい
    // コンストラクター
    public Player()
    {
        Weapon www = new Weapon();
        Armor aaa = new Armor();
        BringWeapon = null;
        www.SelectWeapon(BringWeapon);
        BringArmor = "a200";
        aaa.SelectArmor(BringArmor);

        Name = "名無しさん";
        HP = 100;
        MP = 15;
        ATK = 5;
        DEF = 5;
        Mental = 3;
        AGI = 3;
        EXP = 0;
        Pocket[0] = "i000";
        WeaponWeakAttribute = 0;
        MagicAttribute = 0;

        job = 0;
        level = 1;
        thresholdExp = 20;
    }

    // メソッド
    // ステータスを表示する
    public void DisplayStatus()
    {
        Debug.Log("HP:" + HP
            + " MP:" + MP
            + " ATK:" + ATK
            + " DEF:" + DEF
            + " Mental:" + Mental
            + " AGI:" + AGI
            + " EXP:" + EXP
            + " アイテム:" + Pocket[0]
            + "ジョブ:" + job);
    }

    // プレイヤーのジョブを決める
    public void PlayerJob(int jobID)
    {
        switch (jobID)
        {
            case 0:
                Debug.Log("無職です");
                job = 0;
                break;
            case 1:
                Debug.Log("剣士です。 HP:1.5倍 DEF:1.5倍 Mental:0.5倍");
                job = 1;
                break;
            case 2:
                Debug.Log("魔法使いです。 MP:1.5倍 Mental:1.5倍 HP:0.5倍");
                job = 2;
                break;
            case 3:
                Debug.Log("弓使いです。 ATK:1.5倍 AGI:1.5倍 DEF:0.5倍");
                job = 3;
                break;
            case 4:
                Debug.Log("遊び人です。 AGI:2.5倍");
                job = 4;
                break;
        }
    }

    // 経験値の管理、レベルアップ
    // ジョブによって倍率を変える
    // ステータス確認のため、タプる
    public void PlayerExpManager(int getEXP)
    {
        EXP += getEXP;
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
    }

    // 通常攻撃のインターフェイスを実装
    public (int, int, int) NomalAttack()
    {
        // ((5+6)*5)/3*1.25 = 22
        // 22-5 = 17ダメージ
        Weapon weapon = new Weapon();
        weapon.SelectWeapon(BringWeapon);
        double damage = (ATK + weapon.ATK) * 5 / 3 * 1.25;
        int weAttr = weapon.WeaponAttribute;
        int maAttr = weapon.WeaponMagicAttribute;

        return ((int)damage, weAttr, maAttr);
    }
}