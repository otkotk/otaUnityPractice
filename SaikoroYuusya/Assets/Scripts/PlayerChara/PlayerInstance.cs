using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 通常攻撃のロジック(暫定) -> (this.atk * 5) / 3 * 1.25
    public void NomalAttack()
    {

    }
}
