using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float amplitude; //移動量プロパティ publicなので、Inspector側で数値が設定できる。
    public float speed;     //移動速度プロパティ

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //変位を計算
        float z = amplitude * Mathf.Sin(Time.time * speed); //移動量の計算

        //zを変位させたポジションに再設定
        transform.localPosition = startPosition + new Vector3(0, 0, z); //ポジションの反映 Vector3(y,x,z)
    }
}
