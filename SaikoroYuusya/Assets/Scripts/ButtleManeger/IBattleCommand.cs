﻿using System;
public interface IBattleCommand
{
    // 「こうげき」インターフェイス。相手に対してダメージを与える。
    // 現在選択されている敵キャラに対して攻撃する。
    // 選択されているかの判定は、タグを参照する。
    // 全体攻撃とかどうするんだ
    (int, int, int) NomalAttack(int atk, int we_atk, int we_atrr, int ma_attr);

    // 攻撃を受けるインターフェイス。
    int NomalAttackAccept(int damage, int weAttr, int maAttr, int we_weak, int arm_attr, int ma_attr);

    // 「まほう」インターフェイス。
    //void MagicAttack();

    // 「ぼうぎょ」インターフェイス。コマンドを選択したら、そのターンの終わりまで防御力が2.5倍になる。
    //void Guard();

    // 「アイテム」インターフェイス。所持しているアイテムを表示する。
    // 敵キャラもたまーーーに持っている。
    //void ShowItemDisplay();
}
