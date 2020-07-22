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

    // サイコロで決める
    private int[] saikoro_1 = new int[] { 1, 1, 1, 1, 1, 2, 2, 3 };
    private int[] saikoro_2;

    // サイコロパネルを入れる
    public GameObject saikoroPanel;



    // Use this for initialization
    void Start()
    {
        ShuffleSaikoro();
        //ToughEnemy();
        EnemyAppearanceRandom();
        EnemySelectMethod();
        EnemyGenerate();
        PlayerTag = GameObject.FindWithTag("PlayerTag");
        EnemyTag = GameObject.FindWithTag("EnemyTag");
        EnemyTag.tag = "Selected";
        EnemyTag.GetComponent<EnemyCursor>().ObjectIsActive();
        BattleTextPanelText = BattleTextPanel.GetComponent<Text>();
        StartText();
        //ShowSaikoro();
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
    IEnumerator saikoro()
    {
        saikoroPanel.SetActive(true);
        yield return BattleTextPanelText.text = "画面をタップすると、ルーレットが止まりまぁす";
        GameObject sm = GameObject.FindWithTag("SaikoroManagerTag");
        sm.GetComponent<SaikoroGenerator>().InsertionGameObject();
        sm.GetComponent<SaikoroGenerator>().ShuffleSaikoro();
        sm.GetComponent<SaikoroGenerator>().ChangeColor();
        //while (!Input.GetMouseButtonDown(0))
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(1.5f);
        //StartCoroutine("EnemyAttackAccept");
    }

    public void CoroutineEnemyAttackAccept()
    {
        StartCoroutine("EnemyAttackAccept");
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

        StartCoroutine("saikoro");
        //if (!GameObject.FindWithTag("Selected"))
        //{
        //    EnemyTag = GameObject.FindWithTag("EnemyTag");
        //    EnemyTag.tag = "Selected";
        //}
        //EnemyTag = GameObject.FindWithTag("Selected");


        //StartCoroutine("EnemyAttackAccept");
    }
    IEnumerator EnemyAttackAccept()
    {
        yield return new WaitForSeconds(0.5f);
        BattleTextPanelText.text = "野獣先輩の攻撃ッッッ";
        dSet = PlayerTag.GetComponent<PlayerInstance>().NomalAttack();
        //Debug.Log("ダメージ:" + dSet.damage + "武器属性:" + dSet.weAttr + "魔法属性:" + dSet.maAttr);
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
                yield return BattleTextPanelText.text = "とろけるスライムに" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
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
            case "MiniPlant(Clone)":
                EdSet = EnemyTag.GetComponent<MiniPlantInstance>().NomalAttackAccept(dSet.damage, dSet.weAttr, dSet.maAttr);
                yield return new WaitForSeconds(1.0f);
                yield return BattleTextPanelText.text = "ミニプラントに" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
                dead = EnemyTag.GetComponent<MiniPlantInstance>().isDeath();
                if (dead == true)
                {
                    enemyEncounter--;
                    yield return BattleTextPanelText.text = "ミニプラントは無残にも崩れ落ちた";
                    yield return new WaitForSeconds(0.5f);
                    bufEXP += EnemyTag.GetComponent<MiniPlantInstance>().GetEXP();
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
                yield return BattleTextPanelText.text = "ヌットリアに" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
                dead = EnemyTag.GetComponent<MouseInstance>().isDeath();
                if (dead == true)
                {
                    enemyEncounter--;
                    yield return BattleTextPanelText.text = "ヌットリアは無残にも崩れ落ちた";
                    yield return new WaitForSeconds(0.5f);
                    bufEXP += EnemyTag.GetComponent<MouseInstance>().GetEXP();
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
                yield return BattleTextPanelText.text = "野うさぎに" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
                dead = EnemyTag.GetComponent<RabbitInstance>().isDeath();
                if (dead == true)
                {
                    enemyEncounter--;
                    yield return BattleTextPanelText.text = "野うさぎは無残にも崩れ落ちた";
                    yield return new WaitForSeconds(0.5f);
                    bufEXP += EnemyTag.GetComponent<RabbitInstance>().GetEXP();
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
                yield return BattleTextPanelText.text = "盗賊に" + EdSet + "ダメージ与えた";
                yield return new WaitForSeconds(1.0f);
                dead = EnemyTag.GetComponent<ThiefInstance>().isDeath();
                if (dead == true)
                {
                    enemyEncounter--;
                    yield return BattleTextPanelText.text = "盗賊は無残にも崩れ落ちた";
                    yield return new WaitForSeconds(0.5f);
                    bufEXP += EnemyTag.GetComponent<ThiefInstance>().GetEXP();
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

    // サイコロの中身をシャッフルする
    public void ShuffleSaikoro()
    {
        saikoro_2 = saikoro_1.OrderBy(i => Guid.NewGuid()).ToArray();
    }

    // サイコロがシャッフルされているか確認する
    public void ShowSaikoro()
    {
        foreach(int i in saikoro_2)
        {
            BattleTextPanelText.text += i;
        }
    }

}