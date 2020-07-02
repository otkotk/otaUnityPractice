﻿using System;
public interface IBattleCommand
{
    // 「こうげき」インターフェイス。相手に対してダメージを与える。
    // 現在選択されている敵キャラに対して攻撃する。
    // 選択されているかの判定は、タグを参照する。
    // 全体攻撃とかどうするんだ
    void NomalAttack(int damage, int weaponAttr, int magicAttr);

    // 「まほう」インターフェイス。
    void MagicAttack(int damage, int magicAttr);

    // 「ぼうぎょ」インターフェイス。コマンドを選択したら、そのターンの終わりまで防御力が2.5倍になる。
    void Guard();

    // 「アイテム」インターフェイス。所持しているアイテムを表示する。
    // 敵キャラもたまーーーに持っている。
    void ShowItemDisplay(string[] items);
}