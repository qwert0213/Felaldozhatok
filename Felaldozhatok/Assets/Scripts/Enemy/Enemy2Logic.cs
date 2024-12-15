using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    void Start()
    {
        // Szükséges gameobjectek megkeresése
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        health = 2;
    }

    void Update()
    {
        if (playerCollision.health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (health <= 0)
        {
            // Pénz hozzáadása
            PlayerStats.instance.AddScore(10);
            PlayerStats.instance.AddMoney(10);
            // Ha az ellenség meghal, jelentjük az EnemyManager-nek
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
