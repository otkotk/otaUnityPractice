using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Networking;

public class Player : AbsCharacter
{
    // フィールド
    private int job; //職業
    public int Job { get { return this.job; } set { this.job = value; } }

    private int level = 1; //レベル
    public int Level { get { return this.level; } set { this.level = value; } }

    private int thresholdExp = 20; //これを超えたらレベルアップ
    public int ThresholdExp { get { return this.thresholdExp; } set { this.thresholdExp = value; } }

    private int weapon;
    public int Weapon { get { return this.weapon; } set { this.weapon = value; } }

    private int armor;
    public int Armor { get { return this.armor; } set { this.armor = value; } }

    // メソッド
    // プレイヤーのジョブを決める
    private void PlayerJob(int job)
    {
        switch (job)
        {
            case 0:
                Console.WriteLine("無職です");
                break;
            case 1:
                Console.WriteLine("剣士です");
                break;
            case 2:
                Console.WriteLine("魔法使いです");
                break;
            case 3:
                Console.WriteLine("弓使いです");
                break;
            case 4:
                Console.WriteLine("遊び人です");
                break;
        }
    }

    // 経験値の管理、レベルアップ
    private void PlayerExpManager()
    {
        if(EXP >= thresholdExp)
        {
            level++;
            thresholdExp = level * 10;
        }
    }

    // 継承してきたメソッドを実装
    public int NomalAttack(Enemies e)
    {
        throw new NotImplementedException();
    }

    public override int NomalDefend()
    {
        throw new NotImplementedException();
    }

    public override bool RunEscape()
    {
        throw new NotImplementedException();
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }

}