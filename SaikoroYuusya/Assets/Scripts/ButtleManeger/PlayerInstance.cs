using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    Player player = new Player();

    // Start is called before the first frame update
    void Start()
    {
    }

    // ステータスを表示する
    public void DisplayStatus()
    {
        player.DisplayStatus();
    }

    // 通常攻撃のロジック(暫定) -> (this.atk * 5) / 3 * 1.25
    public void NomalAttack()
    {
        // (5*6)/3*1.5 = 14
        // 14-5 = 9
        // (15*6)/3*1.5 = 45
        // 45-15 = 30
        // (35*6)/3*1.5 = 105
        // 105-35 = 70
    }

    // ジョブをセットする
    public void SetPlayerJob(int jobID)
    {
        player.PlayerJob(jobID);
    }
}
