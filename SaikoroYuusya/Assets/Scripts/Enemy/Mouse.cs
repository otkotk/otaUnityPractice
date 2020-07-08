using UnityEngine;
using System.Collections;
using System;

public class Mouse : Enemies
{
    // コンストラクター
    public Mouse()
    {
        HP = 15;
        MP = 0;
        ATK = 2;
        DEF = 0;
        Mental = 1;
        AGI = 1;
        EXP = 3;
    }

    public override void TestText()
    {
        Debug.Log("スライムです＾＾");
    }
}
