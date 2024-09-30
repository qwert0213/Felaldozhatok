using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health = 1;
    public PlayerAttack playerAttack;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Ellenőrizzük, hogy enemy1 típusú ellenségről van-e szó
            if (gameObject.name.Contains("enemy1"))
            {
                // Pénz hozzáadása
                PlayerStats.instance.AddMoney(10);
            }

            // Ha az ellenség meghal, jelentjük az EnemyManager-nek
            EnemyManager.instance.EnemyKilled();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerAttack")
        {
            health -= playerAttack.damage;
        }
    }
}
