public abstract class Enemies : AbsCharacter
{
    public abstract int NomalAttack(Player p);
    public abstract int NomalDefend(Player p);
    public abstract bool RunEscape(Player p);
    public abstract void UseItem(Player p);
}
