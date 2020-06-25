using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    GameObject gameController;

    void Start()
    {
        // ゲーム開始時にGameControllerをFindしておく
        gameController = GameObject.FindWithTag("GameController");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.SendMessage("IncreaseScore");
    }
}
