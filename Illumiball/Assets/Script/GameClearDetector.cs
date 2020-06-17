﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    public Hole holeRed;
    public Hole holeBlue;
    public Hole holeGreen;

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 2);
        //すべてのボールが入ったらラベルを表示
        if(holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
        {
            GUI.Label(new Rect(44,88,100,30), "YHEAAAAA!!!");
        }
    }
}
