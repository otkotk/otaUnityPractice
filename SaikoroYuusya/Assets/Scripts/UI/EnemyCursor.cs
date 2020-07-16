using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCursor : MonoBehaviour
{
    [SerializeField] GameObject gb;

    public void ObjectIsActive()
    {
        gb.SetActive(true);
    }
}
