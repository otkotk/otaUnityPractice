using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    // Enemyの数を決める。
    private int enemyEncounter;

    // Enemyの種類を格納する
    private int[] enemyKindArr = new int[4];

    private GameObject PlayerTag;
    private GameObject EnemyTag;
    public GameObject BattleTextPanel;
    Text BattleTextPanelText;
    private GameObject enemyObj;

    // ダメージを与える変数
    private (int damage, int weAttr, int maAttr) dSet;

    // ダメージを受ける変数
    private int EdSet;
    private bool dead;
    private int bufEXP = 0;

    // Enemyの下に付いているカーソル
    private GameObject cursor;
    public GameObject camera;

    // 強敵
    private bool toughBool = false;

    // サイコロパネルを入れる
    public GameObject saikoroPanel;



    // Use this for initialization
    void Start()
    {
        ToughEnemy();
        EnemyAppearanceRandom();
        EnemySelectMethod();
        EnemyGenerate();
        PlayerTag = GameObject.FindWithTag("PlayerTag");
        EnemyTag = GameObject.FindWithTag("EnemyTag");
        EnemyTag.tag = "Selected";
        EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
        BattleTextPanelText = BattleTextPanel.GetComponent<Text>();
        StartText();
        PlayerTag.GetComponent<PlayerInstance>().DisplayStatus();
    }

    private void StartText()
    {
        switch (toughBool)
        {
            case false:
                BattleTextPanelText.text = "敵があらわれた！\nどうするぅ？";
                break;
            case true:
                BattleTextPanelText.text = "強敵だ・・・！\nどうするぅ？";
                break;
        }
    }

    IEnumerator saikoro(string actionJudge)
    {
        saikoroPanel.SetActive(true);
        yield return BattleTextPanelText.text = "画面をタップすると、ルーレットが止まりまぁす";
        GameObject sm = GameObject.FindWithTag("SaikoroManagerTag");
        sm.GetComponent<SaikoroGenerator>().InsertionGameObject();
        sm.GetComponent<SaikoroGenerator>().ShuffleSaikoro(actionJudge);
        sm.GetComponent<SaikoroGenerator>().ChangeColor(actionJudge);
        //while (!Input.GetMouseButtonDown(0))
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(1.5f);
        //StartCoroutine("EnemyAttackAccept");
    }

    public void CoroutineEnemyAttackAccept(string cName, string action_j)
    {
        StartCoroutine(EnemyAttackAccept(cName));
    }

    // 「こうげき」ボタン
    // プレイヤーの攻撃メソッド
    // AGIの実装は一旦、保留する＾＾;
    // 全体攻撃は、別で作る
    public void NomalAttack()
    {
        string action_j = "nomal_attack";
        Destroy(camera.GetComponent<Physics2DRaycaster>());
        ButtonInteractable buttonInteractable = new ButtonInteractable();
        buttonInteractable.ButtonInactive();

        StartCoroutine(saikoro(action_j));
        //if (!GameObject.FindWithTag("Selected"))
        //{
        //    EnemyTag = GameObject.FindWithTag("EnemyTag");
        //    EnemyTag.tag = "Selected";
        //}
        //EnemyTag = GameObject.FindWithTag("Selected");


        //StartCoroutine("EnemyAttackAccept");
    }

    public void MagicAttack()
    {
        string action_j = "magic_attack";
        Destroy(camera.GetComponent<Physics2DRaycaster>());
        ButtonInteractable buttonInteractable = new ButtonInteractable();
        buttonInteractable.ButtonInactive();

        StartCoroutine(saikoro(action_j));
    }

    IEnumerator EnemyAttackAccept(string cName)
    {
        yield return new WaitForSeconds(0.5f);
        BattleTextPanelText.text = "";
        if(cName == "Success")
        {
            BattleTextPanelText.text = "サイコロの呪縛に打ち勝った！\n";
            yield return new WaitForSeconds(1.0f);
            BattleTextPanelText.text += "プレイヤーの攻撃ッ\n";
            dSet = PlayerTag.GetComponent<PlayerInstance>().NomalAttack();
            //Debug.Log("ダメージ:" + dSet.damage + "武器属性:" + dSet.weAttr + "魔法属性:" + dSet.maAttr);
        }
        else if(cName == "Failed")
        {
            BattleTextPanelText.text = "サイコロが精神を侵食している！\n";
            yield return new WaitForSeconds(1.0f);
            BattleTextPanelText.text += "攻撃が外れた...\n";
        }
        else if(cName == "Critical")
        {
            BattleTextPanelText.text = "サイコロの呪縛に打ち勝った！\n";
            yield return new WaitForSeconds(1.0f);
            BattleTextPanelText.text += "会心の一撃ッッッ\n";
            dSet = PlayerTag.GetComponent<PlayerInstance>().NomalAttack();
            dSet.damage = (int)(dSet.damage * 1.5);
        }
        EnemyTag = GameObject.FindWithTag("Selected");
        yield return new WaitForSeconds(0.5f);

        string enemyObjName = EnemyTag.name;
        Debug.Log(EnemyTag.tag);

        if(cName != "Failed")
        {
            switch (enemyObjName)
            {
                case "Slime(Clone)":
                    EdSet = EnemyTag.GetComponent<SlimeInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                    yield return new WaitForSeconds(1.0f);
                    yield return BattleTextPanelText.text += "スライムに" + EdSet + "ダメージ与えた";
                    yield return new WaitForSeconds(1.0f);
                    //EnemyTag.GetComponent<SlimeInstance>().ShowStatus();
                    dead = EnemyTag.GetComponent<SlimeInstance>().isDeath();
                    if(dead == true)
                    {
                        enemyEncounter--;
                        yield return BattleTextPanelText.text = "スライムは無残にも崩れ落ちた";
                        bufEXP += EnemyTag.GetComponent<SlimeInstance>().GetEXP();
                        EnemyTag.GetComponent<SlimeInstance>().ObjectDestroy();
                        if (enemyEncounter != 0)
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
                    yield return BattleTextPanelText.text += "キューブスライムに" + EdSet + "ダメージ与えた";
                    yield return new WaitForSeconds(1.0f);
                    dead = EnemyTag.GetComponent<CubeSlimeInstance>().isDeath();
                    if (dead == true)
                    {
                        enemyEncounter--;
                        yield return BattleTextPanelText.text = "キューブスライムは無残にも崩れ落ちた";
                        yield return new WaitForSeconds(0.5f);
                        bufEXP += EnemyTag.GetComponent<CubeSlimeInstance>().GetEXP();
                        EnemyTag.GetComponent<CubeSlimeInstance>().ObjectDestroy();
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
                    yield return BattleTextPanelText.text += "とろけるスライムに" + EdSet + "ダメージ与えた";
                    yield return new WaitForSeconds(1.0f);
                    dead = EnemyTag.GetComponent<MeltSlimeInstance>().isDeath();
                    if (dead == true)
                    {
                        enemyEncounter--;
                        yield return BattleTextPanelText.text = "とろけるスライムは無残にも崩れ落ちた";
                        yield return new WaitForSeconds(0.5f);
                        bufEXP += EnemyTag.GetComponent<MeltSlimeInstance>().GetEXP();
                        EnemyTag.GetComponent<MeltSlimeInstance>().ObjectDestroy();
                        if (enemyEncounter != 0)
                        {
                            EnemyTag = GameObject.FindWithTag("EnemyTag");
                            EnemyTag.tag = "Selected";
                            EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                        }
                    }
                    break;
                case "MiniPlant(Clone)":
                    EdSet = EnemyTag.GetComponent<MiniPlantInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                    yield return new WaitForSeconds(1.0f);
                    yield return BattleTextPanelText.text += "ミニプラントに" + EdSet + "ダメージ与えた";
                    yield return new WaitForSeconds(1.0f);
                    dead = EnemyTag.GetComponent<MiniPlantInstance>().isDeath();
                    if (dead == true)
                    {
                        enemyEncounter--;
                        yield return BattleTextPanelText.text = "ミニプラントは無残にも崩れ落ちた";
                        yield return new WaitForSeconds(0.5f);
                        bufEXP += EnemyTag.GetComponent<MiniPlantInstance>().GetEXP();
                        EnemyTag.GetComponent<MiniPlantInstance>().ObjectDestroy();
                        if (enemyEncounter != 0)
                        {
                            EnemyTag = GameObject.FindWithTag("EnemyTag");
                            EnemyTag.tag = "Selected";
                            EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                        }
                    }
                    break;
                case "Mouse(Clone)":
                    EdSet = EnemyTag.GetComponent<MouseInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                    yield return new WaitForSeconds(1.0f);
                    yield return BattleTextPanelText.text += "ヌットリアに" + EdSet + "ダメージ与えた";
                    yield return new WaitForSeconds(1.0f);
                    dead = EnemyTag.GetComponent<MouseInstance>().isDeath();
                    if (dead == true)
                    {
                        enemyEncounter--;
                        yield return BattleTextPanelText.text = "ヌットリアは無残にも崩れ落ちた";
                        yield return new WaitForSeconds(0.5f);
                        bufEXP += EnemyTag.GetComponent<MouseInstance>().GetEXP();
                        EnemyTag.GetComponent<MouseInstance>().ObjectDestroy();
                        if (enemyEncounter != 0)
                        {
                            EnemyTag = GameObject.FindWithTag("EnemyTag");
                            EnemyTag.tag = "Selected";
                            EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                        }
                    }
                    break;
                case "Rabbit(Clone)":
                    EdSet = EnemyTag.GetComponent<RabbitInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                    yield return new WaitForSeconds(1.0f);
                    yield return BattleTextPanelText.text += "野うさぎに" + EdSet + "ダメージ与えた";
                    yield return new WaitForSeconds(1.0f);
                    dead = EnemyTag.GetComponent<RabbitInstance>().isDeath();
                    if (dead == true)
                    {
                        enemyEncounter--;
                        yield return BattleTextPanelText.text = "野うさぎは無残にも崩れ落ちた";
                        yield return new WaitForSeconds(0.5f);
                        bufEXP += EnemyTag.GetComponent<RabbitInstance>().GetEXP();
                        EnemyTag.GetComponent<RabbitInstance>().ObjectDestroy();
                        if (enemyEncounter != 0)
                        {
                            EnemyTag = GameObject.FindWithTag("EnemyTag");
                            EnemyTag.tag = "Selected";
                            EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                        }
                    }
                    break;
                case "Thief(Clone)":
                    EdSet = EnemyTag.GetComponent<ThiefInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                    yield return new WaitForSeconds(1.0f);
                    yield return BattleTextPanelText.text += "盗賊に" + EdSet + "ダメージ与えた";
                    yield return new WaitForSeconds(1.0f);
                    dead = EnemyTag.GetComponent<ThiefInstance>().isDeath();
                    if (dead == true)
                    {
                        enemyEncounter--;
                        yield return BattleTextPanelText.text = "盗賊は無残にも崩れ落ちた";
                        yield return new WaitForSeconds(0.5f);
                        bufEXP += EnemyTag.GetComponent<ThiefInstance>().GetEXP();
                        EnemyTag.GetComponent<ThiefInstance>().ObjectDestroy();
                        if (enemyEncounter != 0)
                        {
                            EnemyTag = GameObject.FindWithTag("EnemyTag");
                            EnemyTag.tag = "Selected";
                            EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
                        }
                    }
                    break;
            }
        }
        // ここにエフェクトを追加する
        yield return new WaitForSeconds(1.5f);
        //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        if(enemyEncounter == 0)
        {
            yield return new WaitForSeconds(1.0f);
            yield return BattleTextPanelText.text = "経験値 : " + bufEXP;
            yield return BattleTextPanelText.text += "\n戦いに勝利した＾＾";
            PlayerTag.GetComponent<PlayerInstance>().LevelUpConfirm(bufEXP);
            if (toughBool == true)
            {
                toughBool = false;
            }
            yield break;
        }

        StartCoroutine("PlayerAttackAccept");
    }
    IEnumerator PlayerAttackAccept()
    {
        yield return BattleTextPanelText.text = "敵が襲いかかる...!";
        GameObject[] targetSaikoro = GameObject.FindGameObjectsWithTag("Saikoros");
        foreach(GameObject sk in targetSaikoro)
        {
            for(int i=1; i<4; i++)
            {
                GameObject child_sk = sk.transform.GetChild(i).gameObject;
                if (child_sk.activeSelf == true)
                {
                    child_sk.SetActive(false);
                }
            }
        }
        saikoroPanel.SetActive(false);
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
                case "MiniPlant(Clone)":
                    dSet = eg.GetComponent<MiniPlantInstance>().NomalAttack();
                    BattleTextPanelText.text += "ミニプラントは、";
                    break;
                case "Mouse(Clone)":
                    dSet = eg.GetComponent<MouseInstance>().NomalAttack();
                    BattleTextPanelText.text += "ヌットリアは、";
                    break;
                case "Rabbit(Clone)":
                    dSet = eg.GetComponent<RabbitInstance>().NomalAttack();
                    BattleTextPanelText.text += "野うさぎは、";
                    break;
                case "Thief(Clone)":
                    dSet = eg.GetComponent<ThiefInstance>().NomalAttack();
                    BattleTextPanelText.text += "盗賊は、";
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
        //encounter = 100;

        // 強敵マスに止まっていたら、敵を3体に固定する(Level2では趣向を変える)
        if(toughBool == true)
        {
            encounter = 64;
        }

        // 通常の敵マス
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
            int j = random.Next(0, 6);
            enemyKindArr[i] = j;
        }
    }

    // 敵の数だけプレファブを生成する
    private void EnemyGenerate()
    {
        // 1匹:1.25
        // 2匹:0, 2.5
        // 3匹:-1.25, 1.25, 3.75
        // 4匹:-2.5, 0, 2.5, 5
        float[] yee = new float[4];
        switch (enemyEncounter)
        {
            case 1:
                yee[0] = 1.25f;
                break;
            case 2:
                yee[0] = 0f;
                yee[1] = 2.5f;
                break;
            case 3:
                yee[0] = -1.25f;
                yee[1] = 1.25f;
                yee[2] = 3.75f;
                break;
            case 4:
                yee[0] = -2.5f;
                yee[1] = 0f;
                yee[2] = 2.5f;
                yee[3] = 5.0f;
                break;
        }

        for(int i=0; i<enemyEncounter; i++)
        {
            if(toughBool == true)
            {
                enemyKindArr[1] = 6;
            }

            switch (enemyKindArr[i])
            {
                case 0:
                    enemyObj = (GameObject)Resources.Load("Slime");
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 1:
                    enemyObj = (GameObject)Resources.Load("CubeSlime");
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 2:
                    enemyObj = (GameObject)Resources.Load("MeltSlime");
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 3:
                    enemyObj = (GameObject)Resources.Load("MiniPlant");
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 4:
                    enemyObj = (GameObject)Resources.Load("Mouse");
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 5:
                    enemyObj = (GameObject)Resources.Load("Rabbit");
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
                case 6:
                    enemyObj = (GameObject)Resources.Load("Thief");
                    Instantiate(enemyObj, new Vector2(yee[i], 1.4f), Quaternion.identity);
                    break;
            }
        }
    }

    // 強敵マスに止まった場合、この関数を動かす
    public void ToughEnemy()
    {
        toughBool = true;
    }
}