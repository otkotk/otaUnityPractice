using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltSlimeInstance : MonoBehaviour, IEnemy
{
    Enemies meltSlime = new MeltSlime();
    private GameObject EnemyTag;
    public GameObject thisEnemyTag;

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
        GameObject cursor = GameObject.FindWithTag("EnemyCursor");
        cursor.SetActive(false);
        this.GetComponent<EnemyCursor>().ObjectIsActive();
        EnemyTag.tag = "EnemyTag";
        this.tag = "Selected";
    }

    // こうげき
    // 通常攻撃のロジック(暫定) -> (this.atk * 5) / 3 * 1.25
    public (int, int, int) NomalAttack()
    {
        Weapon w = new Weapon();
        w.SelectWeapon(meltSlime.BringWeapon);
        (int damage, int weAttr, int maAttr) dSet = meltSlime.NomalAttack(meltSlime.ATK, w.ATK, w.WeaponAttribute, w.WeaponMagicAttribute);

        return (dSet.damage, dSet.weAttr, dSet.maAttr);
        //(int damage, int weAttr, int maAttr) dSet = player.NomalAttack();
        //return (dSet.damage, dSet.weAttr, dSet.maAttr);
    }

    // ダメージを受けるメソッド
    public int NomalAttackAccept(int damage, int weAttr, int maAttr)
    {
        Armor a = new Armor();
        a.SelectArmor(meltSlime.BringArmor);
        int EdSet = meltSlime.NomalAttackAccept(damage, weAttr, maAttr, meltSlime.WeaponWeakAttribute, a.ArmorAttribute, meltSlime.MagicAttribute);
        meltSlime.HP -= EdSet;
        return EdSet;
    }

    public void ShowStatus()
    {
        Debug.Log("スライムさんの残りHP:" + meltSlime.HP + " スライムさんの属性:" + meltSlime.MagicAttribute);
    }

    // 倒したか確認する
    public bool isDeath()
    {
        bool dead = false;
        if (meltSlime.HP <= 0)
        {
            dead = true;
            //Destroy(this.gameObject);
        }
        return dead;
    }

    // 倒していたら、Hierarchyからオブジェクトを削除する
    public int GetEXP()
    {
        return meltSlime.EXP;
    }

    public void ObjectDestroy()
    {
        Destroy(this.gameObject);
    }
}
