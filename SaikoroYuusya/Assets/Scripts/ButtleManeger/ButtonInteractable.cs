using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractable : MonoBehaviour
{
    GameObject[] buttons;

    void Start()
    {
    }

    // ボタンを無効化
    public void ButtonInactive()
    {
        buttons = GameObject.FindGameObjectsWithTag("buttons");

        foreach(GameObject b in buttons)
        {
            Button button = b.GetComponent<Button>();
            button.interactable = false;
        }
    }

    // ボタンを有効化
    public void ButtonActive()
    {
        buttons = GameObject.FindGameObjectsWithTag("buttons");

        foreach (GameObject b in buttons)
        {
            Button button = b.GetComponent<Button>();
            button.interactable = true;
        }
    }
}
