using UnityEngine;
using System.Collections;

public class ThiefInstance : MonoBehaviour, IEnemy
{
    Enemies thief = new Thief();
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
        w.SelectWeapon(thief.BringWeapon);
        (int damage, int weAttr, int maAttr) dSet = thief.NomalAttack(thief.ATK, w.ATK, w.WeaponAttribute, w.WeaponMagicAttribute);

        return (dSet.damage, dSet.weAttr, dSet.maAttr);
        //(int damage, int weAttr, int maAttr) dSet = player.NomalAttack();
        //return (dSet.damage, dSet.weAttr, dSet.maAttr);
    }

    // ダメージを受けるメソッド
    public int NomalAttackAccept(int damage, int weAttr, int maAttr)
    {
        Armor a = new Armor();
        a.SelectArmor(thief.BringArmor);
        int EdSet = thief.NomalAttackAccept(damage, weAttr, maAttr, thief.WeaponWeakAttribute, a.ArmorAttribute, thief.MagicAttribute);
        thief.HP -= EdSet;
        return EdSet;
    }

    public void ShowStatus()
    {
        Debug.Log("スライムさんの残りHP:" + thief.HP + " スライムさんの属性:" + thief.MagicAttribute);
    }

    // 倒したか確認する
    public bool isDeath()
    {
        bool dead = false;
        if (thief.HP <= 0)
        {
            dead = true;
            //Destroy(this.gameObject);
        }
        return dead;
    }

    // 倒していたら、Hierarchyからオブジェクトを削除する
    public int GetEXP()
    {
        Destroy(this.gameObject);
        return thief.EXP;
    }
}