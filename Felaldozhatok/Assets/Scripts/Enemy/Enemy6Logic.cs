using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    void Start()
    {
        // Sz�ks�ges gameobjectek megkeres�se
        health = 4;
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (playerCollision.health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (health <= 0)
        {
            // P�nz hozz�ad�sa
            PlayerStats.instance.AddScore(25);
            PlayerStats.instance.AddMoney(25);
            // Ha az ellens�g meghal, jelentj�k az EnemyManager-nek
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
