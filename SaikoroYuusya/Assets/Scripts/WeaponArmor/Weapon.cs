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

    private int mental;
    public int Mental { get { return this.mental; } }

    // weaponAttribute 0:無 1:斬撃 2:打撃 3:刺突 4:投擲
    private int weaponAttribute;
    public int WeaponAttribute { get { return this.weaponAttribute; } }

    // magicAttribute 0:無 1:火 2:水 3:電気 4:氷 5:土 6:光 7:闇
    private int weaponMagicAttribute;
    public int WeaponMagicAttribute { get { return this.weaponMagicAttribute; } }

    // タプル型の変数^o^;
    //private (int a, int b) tttuple;

    public void SelectWeapon(string weaponID)
    {
        if (weaponID == null) return;
        // w100:斬撃武器 w200:打撃武器 w300:刺突武器 w400:投擲武器
        if (weaponID.Substring(1,1) == "1")
        {
            // 斬撃武器リスト
            weaponAttribute = 1;
            switch (weaponID)
            {
                case "w100":
                    name = "ヒノキの木刀";
                    atk = 6;
                    break;
                case "w101":
                    name = "ナイフ";
                    atk = 9;
                    break;
                case "w102":
                    name = "長ナイフ";
                    atk = 12;
                    break;
                case "w103":
                    name = "メタルソード";
                    atk = 12;
                    break;
                case "w199":
                    name = "乂夕ﾉレソ一卜゛";
                    atk = 999;
                    break;
            }
        }
        else if(weaponID.Substring(1,1) == "2")
        {
            // 打撃武器リスト
            weaponAttribute = 2;
            switch (weaponID)
            {
                case "w200":
                    name = "ヒノキの棒";
                    atk = 2;
                    break;
                case "w201":
                    name = "太いヒノキの棒";
                    atk = 4;
                    break;
                case "w202":
                    name = "木槌";
                    atk = 7;
                    break;
                case "w203":
                    name = "マジックロッド";
                    atk = 2;
                    mental = 4;
                    break;
            }
        }
        else if(weaponID.Substring(1,1) == "3")
        {
            // 刺突武器リスト
            weaponAttribute = 3;
            switch (weaponID)
            {
                case "w300":
                    name = "フルーレ";
                    atk = 4;
                    break;
                case "w301":
                    name = "レイピア";
                    atk = 7;
                    break;
                case "w302":
                    name = "エペ";
                    atk = 11;
                    break;
            }
        }
        else if(weaponID.Substring(1,1) == "4")
        {
            // 投擲武器リスト
            weaponAttribute = 4;
            switch (weaponID)
            {
                case "w400":
                    name = "石ころ";
                    atk = 2;
                    break;
                case "w401":
                    name = "スリングショット";
                    atk = 8;
                    break;
                case "w402":
                    name = "ショートボウ";
                    atk = 10;
                    break;
            }
        }
        else
        {
            Debug.Log("存在しない武器IDです。");
        }
    }
}