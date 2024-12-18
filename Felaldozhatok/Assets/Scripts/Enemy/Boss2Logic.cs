using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    public AudioSource bossFight;
    void Start()
    {
        // Sz�ks�ges gameobjectek megkeres�se
        health = 15;
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
            PlayerStats.instance.AddScore(150);
            PlayerStats.instance.AddMoney(150);
            bossFight.Stop();
            // Ha az ellens�g meghal, jelentj�k az EnemyManager-nek
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
