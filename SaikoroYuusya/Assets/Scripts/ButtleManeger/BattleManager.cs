using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class BattleManager : MonoBehaviour
{
    public GameObject EnemyObject;
    public GameObject Player;
    Player player;
    double damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NomalAttack()
    {
        GameObject EnemyTag = GameObject.FindWithTag("selected");
        damage = (player.ATK * 5) / 3 * 1.25;
    }
}
