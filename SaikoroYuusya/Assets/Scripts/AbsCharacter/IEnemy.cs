using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    // タグを切り替える
    void SwitchEnemyTag();

    // 行動を選択する
    void SelectAction();
}
