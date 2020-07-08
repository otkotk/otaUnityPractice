using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using System;

public class BattleManager : MonoBehaviour
{
    public double damage;

    // Enemyの数を決める。
    private int enemyEncounter;
    //private Action[] enemySelectArr;
    // private Enemies[] enemies = new Enemies[4];
    private IBattleCommand[] enemies = new IBattleCommand[4];
    private int[] enemySelectArr = new int[4];

    // Enemyが入っている配列。
    // Enemyクラスの分だけ、配列を追加していく。
    // デリゲートメソッドの数と同じにする。
    //private void EnemySet()
    //{
    //    enemySelectArr = new Action[1];
    //    enemySelectArr[0] = DeleSlime;
    //    enemySelectArr[1] = DeleThief;
    //    enemySelectArr[2] = DelePot;
    //}

    // Use this for initialization
    void Start()
    {
        EnemyAppearanceRandom();
        GameObject Player = GameObject.FindWithTag("PlayerTag");
        Player.GetComponent<PlayerInstance>().DisplayStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) testtesttest();
    }

    public void testtesttest()
    {
        GameObject Player = GameObject.FindWithTag("PlayerTag");
        Player.GetComponent<PlayerInstance>().SetPlayerJob(1);
        Player.GetComponent<PlayerInstance>().DisplayStatus();
    }

    // 「こうげき」ボタン
    public void NomalAttack()
    {
        GameObject EnemyObject = GameObject.FindWithTag("Selected");
        EnemyObject.GetComponent<EnemyInstance>();
        GameObject Player = GameObject.FindWithTag("PlayerTag");
        Player.GetComponent<PlayerInstance>().NomalAttack();
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
            int j = random.Next(0, 2);
        }
    }

    // Enemyをランダムで選択するデリゲート
    // Enemyクラスの分だけ、デリゲートを書いていく。
    //private void DeleSlime()
    //{
    //    Enemies slime = new Slime(); 
    //}
    // private void DeleThief() { }
    // private void DelePot() { }
}
