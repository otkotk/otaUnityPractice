using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using System;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    // Enemyの数を決める。
    private int enemyEncounter;
    private Enemies[] es = new Enemies[4];
    private int[] enemySelectArr = new int[4];
    private int[] enemyKindArr = new int[4];
    private GameObject PlayerTag;
    private GameObject EnemyTag;
    public GameObject BattleTextPanel;
    Text BattleTextPanelText;
    private GameObject enemyObj;
    private (int damage, int weAttr, int maAttr) dSet;
    private int EdSet;



    // Use this for initialization
    void Start()
    {
        EnemyAppearanceRandom();
        EnemySelectMethod();
        EnemyGenerate();
        PlayerTag = GameObject.FindWithTag("PlayerTag");
        EnemyTag = GameObject.FindWithTag("EnemyTag");
        EnemyTag.tag = "Selected";
        BattleTextPanelText = BattleTextPanel.GetComponent<Text>();
        StartText();
    }

    private void StartText()
    {
        BattleTextPanelText.text = "敵があらわれた！\nどうするぅ？";
    }

    // 「こうげき」ボタン
    // プレイヤーの攻撃メソッド
    // 速さ順にする場合、同じメソッドを複製するしかないか...
    public void NomalAttack()
    {
        ButtonInteractable buttonInteractable = new ButtonInteractable();
        buttonInteractable.ButtonInactive();

        if (!GameObject.FindWithTag("Selected"))
        {
            EnemyTag = GameObject.FindWithTag("EnemyTag");
            EnemyTag.tag = "Selected";
        }
        EnemyTag = GameObject.FindWithTag("Selected");

        BattleTextPanelText.text = "野獣先輩の攻撃ッッッ";
        dSet = PlayerTag.GetComponent<PlayerInstance>().NomalAttack();
        Debug.Log("ダメージ:" + dSet.damage + "武器属性:" + dSet.weAttr + "魔法属性:" + dSet.maAttr);

        StartCoroutine("EnemyAttackAccept");
    }
    IEnumerator EnemyAttackAccept()
    {
        string enemyObjName = EnemyTag.name;

        switch (enemyObjName)
        {
            case "Slime(Clone)":
                EdSet = EnemyTag.GetComponent<SlimeInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                yield return new WaitForSeconds(0.5f);
                yield return BattleTextPanelText.text = "スライムに" + EdSet + "ダメージ与えた";
                break;
        }
        // ここにエフェクトを追加する
        yield return new WaitForSeconds(1.0f);
        EnemyTag.GetComponent<SlimeInstance>().isDeath();
        //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        StartCoroutine("PlayerAttackAccept");
    }
    IEnumerator PlayerAttackAccept()
    {
        yield return BattleTextPanelText.text = "敵が襲いかかる...!";
        yield return new WaitForSeconds(1.0f);
        if (GameObject.FindWithTag("Selected"))
        {
            EnemyTag = GameObject.FindWithTag("Selected");
            EnemyTag.tag = "EnemyTag";
        }
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTag");
        foreach(GameObject eg in enemyObjects)
        {
            string enemyObjName = eg.name;
            switch (enemyObjName)
            {
                case "Slime(Clone)":
                    dSet = eg.GetComponent<SlimeInstance>().NomalAttack();
                    break;
            }
            Debug.Log("ダメージ:" + dSet.damage + "武器属性:" + dSet.weAttr + "魔法属性:" + dSet.maAttr);
            EdSet = PlayerTag.GetComponent<PlayerInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
            yield return BattleTextPanelText.text = "";
            yield return BattleTextPanelText.text += "プレイヤーに" + EdSet + "ダメージ与えた\n";
            yield return new WaitForSeconds(1.0f);
        }
        ButtonInteractable buttonInteractable = new ButtonInteractable();
        buttonInteractable.ButtonActive();
    }

    // Enemyの数を決めるメソッド。
    private void EnemyAppearanceRandom()
    {
        System.Random random = new System.Random();
        int encounter = random.Next(0, 100);
        if(encounter % 2 == 0 && encounter >= 84)
        {
            enemyEncounter = 4;
        }
        else if(encounter > 62)
        {
            enemyEncounter = 3;
        }
        else if(encounter % 2 == 0)
        {
            enemyEncounter = 2;
        }
        else
        {
            enemyEncounter = 1;
        }
    }

    // Enemyの種類を決めるメソッド。
    private void EnemySelectMethod()
    {
        System.Random random = new System.Random();
        for(int i=0; i<enemyEncounter; i++)
        {
            int j = random.Next(0, 6);
            j = 0;
            enemyKindArr[i] = j;
        }
    }

    // 敵の数だけプレファブを生成する
    private void EnemyGenerate()
    {
        for(int i=0; i<enemyEncounter; i++)
        {
            switch (enemyKindArr[i])
            {
                case 0:
                    enemyObj = (GameObject)Resources.Load("Slime");
                    Instantiate(enemyObj, new Vector2(-5.0f, 1.4f), Quaternion.identity);
                    break;
            }
        }
    }
}
