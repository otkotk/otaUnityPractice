using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public NejikoController nejiko;
    public Text scoreText;
    public LifePanel lifePanel;

    public void Update()
    {
        // スコアを更新
        int score = CalcScore();
        scoreText.text = "Score : " + score + "m";

        // ライフパネルを更新
        lifePanel.UpdateLife(nejiko.Life());
    }

    int CalcScore()
    {
        // ネジ子の走行距離をスコアとする
        return (int)nejiko.transform.position.z;
    }
}
