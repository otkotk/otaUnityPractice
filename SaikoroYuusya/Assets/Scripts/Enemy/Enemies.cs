using UnityEngine;


public abstract class Enemies : AbsCharacter, IBattleCommand
{
    public void Guard()
    {
        Debug.Log("圧倒的・・・・・インターフェイス・・・・・ッッッ");
    }

    public void MagicAttack(int damage, int magicAttr)
    {
        throw new System.NotImplementedException();
    }

    public void NomalAttack(int damage, int weaponAttr, int magicAttr)
    {
        throw new System.NotImplementedException();
    }

    public void ShowItemDisplay(string[] items)
    {
        throw new System.NotImplementedException();
    }

    // 敵キャラは、
    // Enemies抽象クラスと、
    // IBattleCommandインターフェイスを継承して使う。
    public abstract void TestText();
}
