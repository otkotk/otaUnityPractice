using UnityEngine;
using System.Collections;

public class Cursor2TagSwitch : MonoBehaviour
{
    [SerializeField] GameObject parentObj;

    public void EnemySwitchTag4Cursor()
    {
        parentObj.tag = "Selected";
    }
}
