using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemies : AbsCharacter, IBattleCommand
{

    // 敵キャラは、
    // Enemies抽象クラスと、
    // IBattleCommandインターフェイスを継承して使う。
    // 通常攻撃のロジック(暫定) -> (this.atk * 5) / 3 * 1.25
    public (int, int, int) NomalAttack(int atk, int we_atk, int we_atrr, int ma_attr)
    {
        double damage = ((atk + we_atk) * 4.2) / 3 * 1.35;
        int weAttr = we_atrr;
        int maAttr = we_atrr;

        return ((int)damage, weAttr, maAttr);
        //(int damage, int weAttr, int maAttr) dSet = player.NomalAttack();
        //return (dSet.damage, dSet.weAttr, dSet.maAttr);
    }

    //// 通常攻撃のロジック(暫定) -> (this.atk * 5) / 3 * 1.25
    //public (int, int, int) NomalAttack()
    //{
    //    Weapon weapon = new Weapon();
    //    weapon.SelectWeapon(BringWeapon);
    //    double damage = (ATK + weapon.ATK) * 5 / 3 * 1.25;
    //    //int weAttr = weapon.WeaponAttribute;
    //    int weAttr = 3;
    //    int maAttr = weapon.WeaponMagicAttribute;

    //    return ((int)damage, weAttr, maAttr);
    //    //(int damage, int weAttr, int maAttr) dSet = player.NomalAttack();
    //    //return (dSet.damage, dSet.weAttr, dSet.maAttr);
    //}

    public int NomalAttackAccept(int damage, int weAttr, int maAttr, int we_weak, int arm_attr, int ma_attr)
    {
        // ダメージ計算のため、一旦、別の変数に格納しておく
        double changeDamage = 1.0;

        // 武器属性が弱点と同じだったら、ダメージ1.5倍
        // 弱点を突かれていても、防具により耐性をもっていたら、ダメージ1.0倍
        // 耐性をもっていたら、0.75倍
        // 武器属性が0だったら等倍
        if (weAttr != 0)
        {
            if (we_weak != arm_attr && we_weak == weAttr)
            {
                changeDamage *= 1.5;
            }
            else if (we_weak == arm_attr && we_weak == weAttr)
            {
                changeDamage = 1.0;
            }
            else if (we_weak != arm_attr && arm_attr == weAttr)
            {
                changeDamage *= 0.75;
            }
        }

        if (ma_attr != 0)
        {
            switch (ma_attr)
            {
                case 1:
                    // 魔法属性が弱点を突いていたら
                    if (maAttr == 2 || maAttr == 4)
                    {
                        changeDamage *= 1.5;
                    }
                    // 魔法属性に耐性をもっていたら
                    else if (maAttr == 3 || maAttr == 5)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 2:
                    if (maAttr == 3 || maAttr == 5)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 4 || maAttr == 1)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 3:
                    if (maAttr == 4 || maAttr == 1)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 5 || maAttr == 2)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 4:
                    if (maAttr == 5 || maAttr == 2)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 1 || maAttr == 3)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 5:
                    if (maAttr == 1 || maAttr == 3)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 2 || maAttr == 4)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
            }
        }
        int resultDamage = (int)(damage * changeDamage - DEF);
        if(resultDamage <= 0)
        {
            resultDamage = 1;
        }
        return resultDamage;
    }
}
