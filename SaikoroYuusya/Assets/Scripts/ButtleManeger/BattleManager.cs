using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using System;

public class BattleManager : MonoBehaviour
{
    public GameObject EnemyObject;
    public GameObject Player;
    Player player;
    public double damage;

    // Enemyの数を決める。
    private int enemyEncounter;
    private Action[] enemySelectArr;
    private Enemies[] enemies = new Enemies[4];

    // Enemyが入っている配列。
    // Enemyクラスの分だけ、配列を追加していく。
    // デリゲートメソッドの数と同じにする。
    private void EnemySet()
    {
        enemySelectArr = new Action[1];
        enemySelectArr[0] = DeleSlime;
        // enemySelectArr[1] = DeleThief;
        // enemySelectArr[2] = DelePot;
    }

    // Use this for initialization
    void Start()
    {
        EnemySet();
        enemySelectArr[0]();
        EnemyAppearanceRandom();
        Debug.Log(enemyEncounter);

        enemies[0] = new Slime();
        Enemies e1 = new Slime();
        e1.TestText();
        Slime s1 = new Slime();

        for(int i=0; i<enemyEncounter; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NomalAttack()
    {
        GameObject EnemyTag = GameObject.FindWithTag("selected");
        damage = (player.ATK * 5) / 3 * 1.25;
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
            enemySelectArr[j]();
        }
    }

    // Enemyをランダムで選択するデリゲート
    // Enemyクラスの分だけ、デリゲートを書いていく。
    private void DeleSlime()
    {
        Enemies slime = new Slime(); 
        
    }
    // private void DeleThief() { }
    // private void DelePot() { }
}
