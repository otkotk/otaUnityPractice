using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    Player player = new Player();
    int[] prevStatus = new int[6];
    int[] updateStatus = new int[6];

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
        Weapon weapon = new Weapon();
        weapon.SelectWeapon(player.BringWeapon);
        double damage = ((player.ATK + weapon.ATK) * 5) / 3 * 1.25;
        int weAttr = weapon.WeaponAttribute;
        int maAttr = weapon.WeaponMagicAttribute;
        //int maAttr = 3;

        return ((int)damage, weAttr, maAttr);
        //(int damage, int weAttr, int maAttr) dSet = player.NomalAttack();
        //return (dSet.damage, dSet.weAttr, dSet.maAttr);
    }

    // ダメージを受けるメソッド
    public int NomalAttackAccept(int damage, int weAttr, int maAttr)
    {
        Armor a = new Armor();
        a.SelectArmor(player.BringArmor);
        int EdSet = player.NomalAttackAccept(damage, weAttr, maAttr, player.WeaponWeakAttribute, a.ArmorAttribute, player.MagicAttribute);
        player.HP -= EdSet;
        return EdSet;
    }

    // レベルアップ
    //public void LevelUpTest()
    //{
    //    player.LevelUpTest();
    //    Debug.Log("子クラス:" + player.ATK);
    //}
    public (int[], int[]) LevelUpConfirm(int getEXP)
    {
        (int[] p_status, int[] u_status) statuses = player.PlayerExpManager(getEXP);
        Debug.Log(
            "hp" + statuses.p_status[0] +
            "mp" + statuses.p_status[1] +
            "atk" + statuses.p_status[2] +
            "def" + statuses.p_status[3] +
            "mental" + statuses.p_status[4] +
            "agi" + statuses.p_status[5] +
            "\nupdate_hp" + player.HP +
            "update_mp" + player.MP +
            "update_atk" + player.ATK +
            "update_def" + player.DEF +
            "update_mental" + player.Mental +
            "update_agi" + player.AGI);
        return (statuses.p_status, statuses.u_status);
    }

    // ジョブをセットする
    public void SetPlayerJob(int jobID)
    {
        player.PlayerJob(jobID);
    }

}
