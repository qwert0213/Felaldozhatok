using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
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
