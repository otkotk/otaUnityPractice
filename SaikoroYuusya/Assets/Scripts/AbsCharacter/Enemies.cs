using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemies : AbsCharacter, IBattleCommand
{

    // 敵キャラは、
    // Enemies抽象クラスと、
    // IBattleCommandインターフェイスを継承して使う。
    public (int, int, int) NomalAttack()
    {
        throw new System.NotImplementedException();
    }

    public int NomalAttackAccept(int damage, int weAttr, int maAttr)
    {
        // ダメージ計算のため、一旦、別の変数に格納しておく
        double changeDamage = 1.0;

        // 武器属性が弱点と同じだったら、ダメージ1.5倍
        // 弱点を突かれていても、防具により耐性をもっていたら、ダメージ1.0倍
        // 耐性をもっていたら、0.75倍
        // 武器属性が0だったら等倍
        if (weAttr != 0)
        {
            if (WeaponWeakAttribute != ArmorAttribute && WeaponWeakAttribute == weAttr)
            {
                changeDamage *= 1.5;
            }
            else if (WeaponWeakAttribute == ArmorAttribute && WeaponWeakAttribute == weAttr)
            {
                changeDamage = 1.0;
            }
            else if (WeaponWeakAttribute != ArmorAttribute && ArmorAttribute == weAttr)
            {
                changeDamage *= 0.75;
            }
        }

        if (MagicAttribute != 0)
        {
            switch (MagicAttribute)
            {
                case 1:
                    // 魔法属性が弱点を突いていたら
                    if (maAttr == 2 && maAttr == 4)
                    {
                        changeDamage *= 1.5;
                    }
                    // 魔法属性に耐性をもっていたら
                    else if (maAttr == 3 && maAttr == 5)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 2:
                    if (maAttr == 3 && maAttr == 5)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 4 && maAttr == 1)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 3:
                    if (maAttr == 4 && maAttr == 1)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 5 && maAttr == 2)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 4:
                    if (maAttr == 5 && maAttr == 2)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 1 && maAttr == 3)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
                case 5:
                    if (maAttr == 1 && maAttr == 3)
                    {
                        changeDamage *= 1.5;
                    }
                    else if (maAttr == 2 && maAttr == 4)
                    {
                        changeDamage *= 0.75;
                    }
                    break;
            }
        }
        int resultDamage = (int)(damage * changeDamage - DEF);
        return resultDamage;
    }
}
