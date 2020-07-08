using UnityEngine;
using System.Collections;

public class Armor
{
    private string name;
    public string Name { get { return this.name; } }

    private int def;
    public int DEF { get { return this.def; } }

    private int mental;
    public int Mental { get { return this.mental; } }

    private int armorAttribute;
    public int ArmorAttribute { get { return this.armorAttribute; } }

    private int magicAttribute;
    public int MagicAttribute { get { return this.magicAttribute; } }

    public void SelectArmor(string armorID)
    {
        if (armorID == null) return;
        // w100:斬撃耐性 w200:打撃耐性 w300:刺突耐性 w400:投擲耐性
        if (armorID.Substring(1, 1) == "1")
        {
            // 斬撃耐性防具リスト
            armorAttribute = 1;
            switch (armorID)
            {
                case "a100":
                    name = "木製の肩掛け";
                    def = 2;
                    break;
                case "a101":
                    name = "ブリキの胸当て";
                    def = 4;
                    break;
                case "a102":
                    name = "鉄の鎧";
                    def = 7;
                    break;
            }
        }
        else if (armorID.Substring(1, 1) == "2")
        {
            // 打撃耐性防具リスト
            armorAttribute = 2;
            switch (armorID)
            {
                case "a200":
                    name = "皮の鎧";
                    def = 1;
                    break;
                case "a201":
                    name = "厚手の革鎧";
                    def = 4;
                    break;
                case "a202":
                    name = "発泡スチロール";
                    def = 5;
                    magicAttribute = 4;
                    break;
            }
        }
        else if (armorID.Substring(1, 1) == "3")
        {
            // 刺突耐性防具リスト
            armorAttribute = 3;
            switch (armorID)
            {
                case "a300":
                    name = "スライムの服";
                    def = 1;
                    magicAttribute = 2;
                    break;
                case "a301":
                    name = "ヌルヌルした鎧";
                    def = 5;
                    break;
                case "a302":
                    name = "風来人の服";
                    def = 8;
                    break;
            }
        }
        else if (armorID.Substring(1, 1) == "4")
        {
            // 投擲耐性防具リスト
            armorAttribute = 4;
            switch (armorID)
            {
                case "a400":
                    name = "土の鎧";
                    def = 2;
                    break;
                case "a401":
                    name = "古い甲冑";
                    def = 4;
                    break;
                case "a402":
                    name = "硬い羽毛の服";
                    def = 5;
                    break;
            }
        }
        else
        {
            Debug.Log("存在しない防具IDです。");
        }
    }
}
