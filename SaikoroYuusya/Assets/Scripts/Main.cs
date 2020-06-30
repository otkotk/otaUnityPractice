using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Weapon we = new Weapon();
        // コンストラクター
        // public Slime(string name, )
        we.SelectWeapon("w103");
        Debug.Log(we.Name);

        Slime slime = new Slime();
        Debug.Log(slime.Weapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
