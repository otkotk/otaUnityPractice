public abstract class AbsCharacter
{
    // フィールド
    private string name;
    public string Name { get { return this.name; } set { this.name = value; } }

    private int hp;
    public int HP { get { return this.HP; } set { this.hp = value; } }

    private int mp;
    public int MP { get { return this.MP; } set { this.mp = value; } }

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

    private int[] pocket = new int[20]; //アイテム入れ

    private string bringWeapon;
    public string BringWeapon { get { return this.bringWeapon; } set { this.bringWeapon = value; } }

    private int weaponAttribute;
    public int WeaponAttribute { get { return this.weaponAttribute; } set { this.weaponAttribute = value; } }

    private int weaponMagicAttribute;
    public int WeaponMagicAttribute { get { return this.weaponMagicAttribute; } set { this.weaponMagicAttribute = value; } }

    private int weaponWeakAttribute;
    public int WeaponWeakAttribute { get { return this.weaponWeakAttribute; } set { this.weaponWeakAttribute = value; } }

    private string armor;
    public string Armor { get { return this.armor; } set { this.armor = value; } }

    // 武器属性に対する耐性。ダメージを1/3カットする。弱点と耐性が同じだった場合、ダメージは等倍になる。
    private int armorAtrribute;
    public int ArmorAttribute { get { return this.armorAtrribute; } set { this.armorAtrribute = value; } }

    // 魔法属性に対する耐性。ダメージを1/3カットする。弱点と耐性が同じだった場合、ダメージは等倍になる。
    private int magicWeakAttribute;
    public int MagicWeakAttribute { get { return this.magicWeakAttribute; } set { this.magicWeakAttribute = value; } }

    // public abstract int NomalAttack();
    //public abstract int NomalDefend();
    //public abstract bool RunEscape();
    //public abstract void UseItem();
}
