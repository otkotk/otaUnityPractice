﻿using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleManager : MonoBehaviour
{
    // Enemyの数を決める。
    private int enemyEncounter;
    private int[] enemyKindArr = new int[4];
    private GameObject PlayerTag;
    private GameObject EnemyTag;
    public GameObject BattleTextPanel;
    Text BattleTextPanelText;
    private GameObject enemyObj;
    private (int damage, int weAttr, int maAttr) dSet;
    private int EdSet;
    private bool dead;
    private int bufEXP = 0;
    private GameObject cursor;
    public GameObject camera;



    // Use this for initialization
    void Start()
    {
        EnemyAppearanceRandom();
        EnemySelectMethod();
        EnemyGenerate();
        PlayerTag = GameObject.FindWithTag("PlayerTag");
        EnemyTag = GameObject.FindWithTag("EnemyTag");
        EnemyTag.tag = "Selected";
        EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
        BattleTextPanelText = BattleTextPanel.GetComponent<Text>();
        StartText();
    }

    private void StartText()
    {
        BattleTextPanelText.text = "敵があらわれた！\nどうするぅ？";
    }

    // 「こうげき」ボタン
    // プレイヤーの攻撃メソッド
    // AGIの実装は一旦、保留する＾＾;
    // 全体攻撃は、別で作る
    public void NomalAttack()
    {
        Destroy(camera.GetComponent<Physics2DRaycaster>());
        ButtonInteractable buttonInteractable = new ButtonInteractable();
        buttonInteractable.ButtonInactive();

        //if (!GameObject.FindWithTag("Selected"))
        //{
        //    EnemyTag = GameObject.FindWithTag("EnemyTag");
        //    EnemyTag.tag = "Selected";
        //}
        //EnemyTag = GameObject.FindWithTag("Selected");

        BattleTextPanelText.text = "野獣先輩の攻撃ッッッ";
        dSet = PlayerTag.GetComponent<PlayerInstance>().NomalAttack();
        Debug.Log("ダメージ:" + dSet.damage + "武器属性:" + dSet.weAttr + "魔法属性:" + dSet.maAttr);

        StartCoroutine("EnemyAttackAccept");
    }
    IEnumerator EnemyAttackAccept()
    {
        EnemyTag = GameObject.FindWithTag("Selected");
        yield return new WaitForSeconds(0.5f);
        string enemyObjName = EnemyTag.name;
        Debug.Log(EnemyTag.tag);

        switch (enemyObjName)
        {
            case "Slime(Clone)":
                EdSet = EnemyTag.GetComponent<SlimeInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                yield return new WaitForSeconds(1.0f);
                yield return BattleTextPanelText.text = "スライムに" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
                //EnemyTag.GetComponent<SlimeInstance>().ShowStatus();
                dead = EnemyTag.GetComponent<SlimeInstance>().isDeath();
                if(dead == true)
                {
                    enemyEncounter--;
                    yield return BattleTextPanelText.text = "スライムは無残にも崩れ落ちた";
                    bufEXP += EnemyTag.GetComponent<SlimeInstance>().GetEXP();
                    if(enemyEncounter != 0)
                    {
                    EnemyTag = GameObject.FindWithTag("EnemyTag");
                    EnemyTag.tag = "Selected";
                    EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                    }
                }
                break;
            case "CubeSlime(Clone)":
                EdSet = EnemyTag.GetComponent<CubeSlimeInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                yield return new WaitForSeconds(1.0f);
                yield return BattleTextPanelText.text = "キューブスライムに" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
                //EnemyTag.GetComponent<SlimeInstance>().ShowStatus();
                dead = EnemyTag.GetComponent<CubeSlimeInstance>().isDeath();
                if (dead == true)
                {
                    enemyEncounter--;
                    yield return BattleTextPanelText.text = "キューブスライムは無残にも崩れ落ちた";
                    yield return new WaitForSeconds(0.5f);
                    bufEXP += EnemyTag.GetComponent<CubeSlimeInstance>().GetEXP();
                    if (enemyEncounter != 0)
                    {
                        EnemyTag = GameObject.FindWithTag("EnemyTag");
                        EnemyTag.tag = "Selected";
                        EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                    }
                }
                break;
            case "MeltSlime(Clone)":
                EdSet = EnemyTag.GetComponent<MeltSlimeInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                yield return new WaitForSeconds(1.0f);
                yield return BattleTextPanelText.text = "キューブスライムに" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
                //EnemyTag.GetComponent<SlimeInstance>().ShowStatus();
                dead = EnemyTag.GetComponent<MeltSlimeInstance>().isDeath();
                if (dead == true)
                {
                    enemyEncounter--;
                    yield return BattleTextPanelText.text = "とろけるスライムは無残にも崩れ落ちた";
                    yield return new WaitForSeconds(0.5f);
                    bufEXP += EnemyTag.GetComponent<MeltSlimeInstance>().GetEXP();
                    if (enemyEncounter != 0)
                    {
                        EnemyTag = GameObject.FindWithTag("EnemyTag");
                        EnemyTag.tag = "Selected";
                        EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                    }
                }
                break;
        }
        // ここにエフェクトを追加する
        yield return new WaitForSeconds(1.5f);
        //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        if(enemyEncounter == 0)
        {
            yield return new WaitForSeconds(1.0f);
            yield return BattleTextPanelText.text = "経験値 : " + bufEXP;
            yield return BattleTextPanelText.text += "\n戦いに勝利した＾＾";
            yield break;
        }

        StartCoroutine("PlayerAttackAccept");
    }
    IEnumerator PlayerAttackAccept()
    {
        yield return BattleTextPanelText.text = "敵が襲いかかる...!";
        yield return new WaitForSeconds(1.0f);
        yield return BattleTextPanelText.text = "";
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
                    BattleTextPanelText.text += "スライムは、";
                    break;
                case "CubeSlime(Clone)":
                    dSet = eg.GetComponent<CubeSlimeInstance>().NomalAttack();
                    BattleTextPanelText.text += "キューブスライムは、";
                    break;
                case "MeltSlime(Clone)":
                    dSet = eg.GetComponent<MeltSlimeInstance>().NomalAttack();
                    BattleTextPanelText.text += "とろけるスライムは、";
                    break;
            }
            Debug.Log("ダメージ:" + dSet.damage + "武器属性:" + dSet.weAttr + "魔法属性:" + dSet.maAttr);
            EdSet = PlayerTag.GetComponent<PlayerInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
            yield return BattleTextPanelText.text += "プレイヤーに" + EdSet + "ダメージ与えた\n";
            yield return new WaitForSeconds(1.0f);
        }
        // アクティブなcursorを探して、その親要素のタグを"Selected"に変更する
        cursor = GameObject.FindWithTag("EnemyCursor");
        cursor.GetComponent<Cursor2TagSwitch>().EnemySwitchTag4Cursor();
        camera.AddComponent<Physics2DRaycaster>();
        ButtonInteractable buttonInteractable = new ButtonInteractable();
        buttonInteractable.ButtonActive();
    }

    // Enemyの数を決めるメソッド。
    private void EnemyAppearanceRandom()
    {
        System.Random random = new System.Random();
        int encounter = random.Next(0, 100);
        encounter = 100;
        if (encounter % 2 == 0 && encounter >= 84)
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
            int j = random.Next(0, 3);
            enemyKindArr[i] = j;
        }
    }

    // 敵の数だけプレファブを生成する
    private void EnemyGenerate()
    {
        float[] yee = new float[4];
        if(enemyEncounter == 1)
        {
            yee[0] = 1.25f;
        }
        else if(enemyEncounter == 2)
        {
            yee[0] = 0f;
            yee[1] = 2.5f;
        }
        else if(enemyEncounter == 3)
        {
            yee[0] = -1.25f;
            yee[1] = 1.25f;
            yee[2] = 3.75f;
        }
        else
        {
            yee[0] = -2.5f;
            yee[1] = 0f;
            yee[2] = 2.5f;
            yee[3] = 5.0f;
        }

        for(int i=0; i<enemyEncounter; i++)
        {
            switch (enemyKindArr[i])
            {
                case 0:
                    enemyObj = (GameObject)Resources.Load("Slime");
                    // 1匹:1.25
                    // 2匹:0, 2.5
                    // 3匹:-1.25, 1.25, 3.75
                    // 4匹:-2.5, 0, 2.5, 5
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 1:
                    enemyObj = (GameObject)Resources.Load("CubeSlime");
                    // 1匹:1.25
                    // 2匹:0, 2.5
                    // 3匹:-1.25, 1.25, 3.75
                    // 4匹:-2.5, 0, 2.5, 5
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 2:
                    enemyObj = (GameObject)Resources.Load("MeltSlime");
                    // 1匹:1.25
                    // 2匹:0, 2.5
                    // 3匹:-1.25, 1.25, 3.75
                    // 4匹:-2.5, 0, 2.5, 5
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
            }
        }
    }
}
