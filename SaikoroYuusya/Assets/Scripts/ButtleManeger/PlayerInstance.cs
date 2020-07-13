﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, IBattleCommand
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
        Weapon weapon = new Weapon();
        weapon.SelectWeapon(player.BringWeapon);
        double damage = (player.ATK + weapon.ATK) * 5 / 3 * 1.25;
        int weAttr = weapon.WeaponAttribute;
        int maAttr = weapon.WeaponMagicAttribute;

        return ((int)damage, weAttr, maAttr);
        //(int damage, int weAttr, int maAttr) dSet = player.NomalAttack();
        //return (dSet.damage, dSet.weAttr, dSet.maAttr);
    }

    // ジョブをセットする
    public void SetPlayerJob(int jobID)
    {
        player.PlayerJob(jobID);
    }

    public int NomalAttackAccept(int damage, int weAttr, int maAttr)
    {
        throw new System.NotImplementedException();
    }
}
