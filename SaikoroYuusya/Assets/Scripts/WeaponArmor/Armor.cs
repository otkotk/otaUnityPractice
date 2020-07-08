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
        // w000:斬撃耐性 w100:打撃耐性 w200:刺突耐性 w300:投擲耐性
        if (armorID.Substring(1, 1) == "1")
        {

        }
        else if (armorID.Substring(1, 1) == "2")
        {

        }
        else if (armorID.Substring(1, 1) == "3")
        {

        }
        else if (armorID.Substring(1, 1) == "4")
        {

        }
    }
}
