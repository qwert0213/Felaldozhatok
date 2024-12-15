using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int travelSpeed = 10;
    public int damage = 1;
    public EnemyLogic enemyLogic;

    public void Update()
    {
        // Lövedék haladása és 'felesés' figyelés
        transform.position = new Vector3(transform.position.x, transform.position.y + travelSpeed * Time.deltaTime, 0);
        if (transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        // Ütközés figyelése
        if (other.gameObject.tag == "enemy1" || other.gameObject.tag == "enemy2" || other.gameObject.tag == "enemy3" || other.gameObject.tag == "enemy4" || other.gameObject.tag == "enemy5" || other.gameObject.tag == "enemy6" || other.gameObject.tag == "boss1" || other.gameObject.tag == "boss2" | other.gameObject.tag == "boss3")
        {
            Destroy(this.gameObject);
        }
    }

    public void UpgradeDamage(int extraDamage)
    {
        // Sebzés növelése
        damage += extraDamage;
    }

    public void UpgradeProjectileSpeed(int extraSpeed)
    {
        // Lövedék sebességének növelése
        travelSpeed += extraSpeed;
    }
}