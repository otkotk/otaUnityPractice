using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    Enemies slime = new Slime();

    public void umasi()
    {
        Debug.Log("タグから呼ばれたよぉー");
    }
}
