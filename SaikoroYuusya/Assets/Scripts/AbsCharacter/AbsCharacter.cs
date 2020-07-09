public abstract class AbsCharacter
{
    // フィールド
    private string name;
    public string Name { get { return this.name; } set { this.name = value; } }

    private int hp;
    public int HP { get { return this.hp; } set { this.hp = value; } }

    private int mp;
    public int MP { get { return this.mp; } set { this.mp = value; } }

    private int atk;
    public int ATK { get { return this.atk; } set { this.atk = value; } }

    private int def;
    public int DEF { get { return this.def; } set { this.def = value; } }

    private int mental;
    public int Mental { get { return this.mental; } set { this.mental = value; } }

    private int agi;
    public int AGI { get { return this.agi; } set { this.agi = value; } }

    private int exp; //現在の総経験値
    public int EXP { get { return this.exp; } set { this.exp = value; } }

    private string[] pocket = new string[20]; //アイテム入れ
    public string[] Pocket { get { return this.pocket; } set { this.pocket = value; } }

    // 持っている武器
    private string bringWeapon;
    public string BringWeapon { get { return this.bringWeapon; } set { this.bringWeapon = value; } }

    // 武器属性などは、フィールドに格納するのではなく、都度呼び出して使った方がイケメンかも^o^
    // 武器属性(いらないかも)
    //private int weaponAttribute;
    //public int WeaponAttribute { get { return this.weaponAttribute; } set { this.weaponAttribute = value; } }

    // 武器に付与されている魔法属性(いらないかも)
    //private int weaponMagicAttribute;
    //public int WeaponMagicAttribute { get { return this.weaponMagicAttribute; } set { this.weaponMagicAttribute = value; } }

    // キャラの武器属性の弱点
    private int weaponWeakAttribute;
    public int WeaponWeakAttribute { get { return this.weaponWeakAttribute; } set { this.weaponWeakAttribute = value; } }

    // 身につけている防具
    private string bringArmor;
    public string BringArmor { get { return this.bringArmor; } set { this.bringArmor = value; } }

    // 盾^^; 両手武器とかは余裕があったら作るゾ
    //private string shield;
    //public string Shield { get { return this.shield; } set { this.shield = value; } }

    // 武器属性に対する耐性。ダメージを1/3カットする。弱点と耐性が同じだった場合、ダメージは等倍になる。
    // (いらないかも)
    private int armorAtrribute;
    public int ArmorAttribute { get { return this.armorAtrribute; } set { this.armorAtrribute = value; } }

    // キャラが持っている属性、キャラによって設定する。
    // 魔法属性に対する耐性。ダメージを1/3カットする。弱点と耐性が同じだった場合、ダメージは等倍になる。
    private int magicAttribute;
    public int MagicAttribute { get { return this.magicAttribute; } set { this.magicAttribute = value; } }

}
