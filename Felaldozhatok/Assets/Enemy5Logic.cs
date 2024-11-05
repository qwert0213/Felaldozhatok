using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollision.health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (health <= 0)
        {

            // P�nz hozz�ad�sa
            PlayerStats.instance.AddScore(50);
            PlayerStats.instance.AddMoney(50);


            // Ha az ellens�g meghal, jelentj�k az EnemyManager-nek
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
