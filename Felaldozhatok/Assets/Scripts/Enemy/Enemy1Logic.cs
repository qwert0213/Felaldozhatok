using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    void Start()
    {
        // Szükséges gameobjectek megkeresése
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
            // Pénz hozzáadása
            PlayerStats.instance.AddScore(20);
            PlayerStats.instance.AddMoney(20);
            // Ha az ellenség meghal, jelentjük az EnemyManager-nek
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
