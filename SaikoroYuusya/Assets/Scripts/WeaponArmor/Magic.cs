using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic
{
    private string name = "名も無きマホー";
    public string Name { get { return this.name; } }

    private int atk = 0;
    public int ATK { get { return this.atk; } }

    // magicAttribute 0:無 1:火 2:水 3:電気 4:土 5:氷 6:光 7:闇
    private int magicAttribute = 0;
    public int MagicAttribute { get { return this.magicAttribute; } }

    // weaponAttribute 0:無 1:斬撃 2:打撃 3:刺突 4:投擲
    private int weaponAttribute = 0;
    public int WeaponAttribute { get { return this.weaponAttribute; } }

    public void SelectWeapon(string magicID)
    {
        if (magicID == null) return;
        // m000:無 m100:火 m200:水 m300:電気 m400:土 m500:氷 m600:光 m700:闇
        if (magicID.Substring(1, 1) == "0")
        {
            // 無属性、魔法攻撃リスト
            magicAttribute = 0;
            switch (magicID)
            {
                case "m000":
                    name = "フラッシュライト";
                    atk = 0;
                    break;
                case "m001":
                    name = "波動砲";
                    atk = 15;
                    break;
                case "m002":
                    name = "しねしねこうせん";
                    atk = 30;
                    break;
                case "m003":
                    name = "メテオ";
                    atk = 66;
                    weaponAttribute = 4;
                    break;
                case "m004":
                    name = "カタストロフィ";
                    atk = 120;
                    break;
                case "m099":
                    name = "カメハメﾌｧｯ!?゛";
                    atk = 999;
                    break;
            }
        }
        else if (magicID.Substring(1, 1) == "1")
        {
            // 火属性、魔法攻撃リスト
            magicAttribute = 1;
            switch (magicID)
            {
                case "m100":
                    name = "プチフレア";
                    atk = 5;
                    break;
                case "m101":
                    name = "フレア";
                    atk = 10;
                    break;
                case "m102":
                    name = "メガフレア";
                    atk = 30;
                    break;
                case "m103":
                    name = "ファイアーアロー";
                    atk = 8;
                    weaponAttribute = 4;
                    break;
            }
        }
        else if (magicID.Substring(1, 1) == "2")
        {
            // 水属性、魔法攻撃リスト
            magicAttribute = 2;
            switch (magicID)
            {
                case "m200":
                    name = "ハイドロショット";
                    atk = 6;
                    break;
            }
        }
        else if (magicID.Substring(1, 1) == "3")
        {
            // 電気属性、魔法攻撃リスト
            magicAttribute = 3;
            switch (magicID)
            {
                case "m300":
                    name = "ショックサンダー";
                    atk = 6;
                    break;
            }
        }
        else if (magicID.Substring(1, 1) == "4")
        {
            // 電気属性、魔法攻撃リスト
            magicAttribute = 4;
            switch (magicID)
            {
                case "m400":
                    name = "サンドショット";
                    atk = 6;
                    break;
            }
        }
        else if (magicID.Substring(1, 1) == "5")
        {
            // 電気属性、魔法攻撃リスト
            magicAttribute = 5;
            switch (magicID)
            {
                case "m500":
                    name = "アイスショット";
                    atk = 8;
                    break;
            }
        }
        else if (magicID.Substring(1, 1) == "6")
        {
            // 電気属性、魔法攻撃リスト
            magicAttribute = 6;
            switch (magicID)
            {
                case "m600":
                    name = "ホーリーライト";
                    atk = 23;
                    break;
            }
        }
        else if (magicID.Substring(1, 1) == "7")
        {
            // 電気属性、魔法攻撃リスト
            magicAttribute = 7;
            switch (magicID)
            {
                case "m700":
                    name = "ダークネス";
                    atk = 23;
                    break;
            }
        }
        else
        {
            Debug.Log("存在しない魔法IDです。");
        }
    }
}
