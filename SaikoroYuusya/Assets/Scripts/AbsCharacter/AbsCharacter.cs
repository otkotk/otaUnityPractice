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

    private int exp = 0; //現在の総経験値
    public int EXP { get { return this.exp; } set { this.exp = value; } }

    private int[] pocket = new int[7]; //アイテム入れ

    // public abstract int NomalAttack();
    public abstract int NomalDefend();
    public abstract bool RunEscape();
    public abstract void UseItem();
}
