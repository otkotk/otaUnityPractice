using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeInstance : MonoBehaviour, IEnemy
{
    Enemies slime = new Slime();
    private GameObject EnemyTag;
    private GameObject TagSelected;

    void Start()
    {
        EnemyTag = GameObject.FindWithTag("EnemyTag");
    }

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

        // テスト用に、攻撃だけ実行するようにする
        actionExe = 1;

        switch (actionExe)
        {
            case 1:
                Debug.Log("こうげき");
                break;
            case 2:
                Debug.Log("まほう");
                break;
            case 3:
                Debug.Log("ぼうぎょ");
                break;
            case 4:
                Debug.Log("アイテム");
                break;
            case 5:
                Debug.Log("にげる");
                break;
        }
    }

    // タグを切り替えるインターフェイスを実装
    public void SwitchEnemyTag()
    {
        EnemyTag = GameObject.FindWithTag("Selected");
        EnemyTag.tag = "EnemyTag";
        Debug.Log(EnemyTag.tag);
        EnemyTag.tag = "Selected";
        Debug.Log(EnemyTag.tag);
    }

    public int NomalAttackAccept(int damage, int weAttr, int maAttr)
    {
        int EdSet = slime.NomalAttackAccept(damage, weAttr, maAttr);
        slime.HP -= EdSet;
        return EdSet;
    }

    public void ShowStatus()
    {
        Debug.Log("スライムさんの残りHP:" + slime.HP);
    }

    public void isDeath()
    {
        if (slime.HP <= 0) Destroy(this.gameObject);
    }
}
