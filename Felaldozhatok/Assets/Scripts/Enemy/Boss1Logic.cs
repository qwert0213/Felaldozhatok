using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Logic : EnemyLogic
{
    public EnemyManager enemyManager;
    public AudioSource bossFight;
    // Start is called before the first frame update
    void Start()
    {
        health = 8;
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
        bossFight = GameObject.Find("BossFight").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {

            // P�nz hozz�ad�sa
            PlayerStats.instance.AddScore(100);
            PlayerStats.instance.AddMoney(100);
            bossFight.Stop();

            // Ha az ellens�g meghal, jelentj�k az EnemyManager-nek
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
