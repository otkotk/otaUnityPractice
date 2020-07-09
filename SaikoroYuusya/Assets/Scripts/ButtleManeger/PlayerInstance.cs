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
    public (int, int, int) NomalAttack()
    {
        (int damage, int weAttr, int maAttr) dSet = player.NomalAttack();
        return (dSet.damage, dSet.weAttr, dSet.maAttr);
    }

    // ジョブをセットする
    public void SetPlayerJob(int jobID)
    {
        player.PlayerJob(jobID);
    }
}
