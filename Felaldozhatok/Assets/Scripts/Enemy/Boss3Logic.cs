using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    public AudioSource bossFight;
    void Start()
    {
        // Sz�ks�ges gameobjectek megkeres�se
        health = 30;
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
        bossFight = GameObject.Find("BossFight").GetComponent<AudioSource>();
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
            PlayerStats.instance.AddScore(300);
            PlayerStats.instance.AddMoney(300);
            bossFight.Stop();

            // Ha az ellens�g meghal, jelentj�k az EnemyManager-nek
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
