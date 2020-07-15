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
}
