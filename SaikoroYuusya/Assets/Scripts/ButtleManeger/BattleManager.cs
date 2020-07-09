using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using System;

public class BattleManager : MonoBehaviour
{
    public double damage;

    // Enemyの数を決める。
    private int enemyEncounter;
    private IBattleCommand[] enemies = new IBattleCommand[4];
    private int[] enemySelectArr = new int[4];
    private int[] enemyKindArr = new int[4];



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonUp("Fire1")) testtesttest();
    }

    // 「こうげき」ボタン
    public void NomalAttack()
    {
        GameObject EnemyObject = GameObject.FindWithTag("Selected");
        GameObject Player = GameObject.FindWithTag("PlayerTag");

        (int damage, int weAttr, int maAttr) dSet = Player.GetComponent<PlayerInstance>().NomalAttack();
        Debug.Log("ダメージ:" + dSet.damage + "武器属性:" + dSet.weAttr + "魔法属性:" + dSet.maAttr);

        //StartCoroutine("EnemyAttackAccept");
    }
    //IEnumerator EnemyAttackAccept()
    //{
    //}

    // Enemyの数を決めるメソッド。
    private void EnemyAppearanceRandom()
    {
        System.Random random = new System.Random();
        int encounter = random.Next(0, 100);
        if(encounter % 2 == 0 && encounter >= 84)
        {
            enemyEncounter = 4;
        }
        else if(encounter > 70)
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
            int j = random.Next(0, 4);
            enemyKindArr[i] = j;
        }
    }

    // 敵の数だけプレファブを生成する
    private void EnemyGenerate()
    {
        for(int i=0; i<enemyEncounter; i++)
        {

        }
    }
}
