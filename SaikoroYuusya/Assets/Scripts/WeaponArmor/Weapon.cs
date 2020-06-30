using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon
{
    private string name;
    public string Name { get { return this.name; } }

    private int atk;
    public int ATK { get { return this.atk; } }

    private int mental = 0;
    // weaponAttribute 0:斬撃 1:打撃 2:刺突 3:投擲
    private int weaponAttribute = 0;
    // magicAttribute 0:無 1:火 2:水 3:電気 4:氷 5:土 6:光 7:闇
    private int magicAttribute = 0;

    public void SelectWeapon(string weaponID)
    {
        // w000:斬撃武器 w100:打撃武器 w200:刺突武器 w300:投擲武器
        if (weaponID.Substring(1,1) == "0")
        {
            // 斬撃武器リスト
            weaponAttribute = 0;
            switch (weaponID)
            {
                case "w000":
                    name = "ヒノキの木刀";
                    atk = 6;
                    break;
                case "w001":
                    name = "ナイフ";
                    atk = 9;
                    break;
                case "w002":
                    name = "長ナイフ";
                    atk = 12;
                    break;
            }
        }
        else if(weaponID.Substring(1,1) == "1")
        {
            // 打撃武器リスト
            weaponAttribute = 1;
            switch (weaponID)
            {
                case "w100":
                    name = "ヒノキの棒";
                    atk = 2;
                    break;
                case "w101":
                    name = "太いヒノキの棒";
                    atk = 4;
                    break;
                case "w102":
                    name = "木槌";
                    atk = 7;
                    break;
                case "w103":
                    name = "マジックロッド";
                    atk = 2;
                    mental = 4;
                    break;
            }
        }
        else if(weaponID.Substring(1,1) == "2")
        {
            // 刺突武器リスト
            weaponAttribute = 2;
            switch (weaponID)
            {
                case "w200":
                    name = "フルーレ";
                    atk = 4;
                    break;
                case "w201":
                    name = "レイピア";
                    atk = 7;
                    break;
                case "w202":
                    name = "エペ";
                    atk = 11;
                    break;
            }
        }
        else if(weaponID.Substring(1,1) == "3")
        {
            // 投擲武器リスト
            weaponAttribute = 3;
            switch (weaponID)
            {
                case "w300":
                    name = "石ころ";
                    atk = 2;
                    break;
                case "w301":
                    name = "スリングショット";
                    atk = 8;
                    break;
                case "w302":
                    name = "ショートボウ";
                    atk = 10;
                    break;
            }
        }
    }
}