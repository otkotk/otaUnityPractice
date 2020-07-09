using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeInstance : MonoBehaviour
{
    Enemies slime = new Slime();

    // Enemiesの行動を選択する
    // 序盤は攻撃しかしない。
    // Playerの行動の後にコルーチンで最初に呼ばれる。
    // Enemiesの処理が終わった後に、テキストなどを表示する。
    // 例:30のダメージを与えた

    // こうげき、ぼうぎょ、まほう、アイテム、にげる
    public void SelectAction()
    {
        System.Random random = new System.Random();
        int actionExe = random.Next(1, 5);
        // テスト用に、攻撃と防御だけ実行するようにする
        actionExe = random.Next(1, 2);

        switch (actionExe)
        {
            case 1:
                Debug.Log("こうげき");
                break;
            case 2:
                Debug.Log("ぼうぎょ");
                break;
            case 3:
                Debug.Log("まほう");
                break;
            case 4:
                Debug.Log("アイテムを使う");
                break;
            case 5:
                Debug.Log("にげる");
                break;
        }
    }

}
