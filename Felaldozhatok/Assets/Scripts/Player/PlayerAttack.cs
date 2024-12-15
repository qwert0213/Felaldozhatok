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
        // L�ved�k halad�sa �s 'feles�s' figyel�s
        transform.position = new Vector3(transform.position.x, transform.position.y + travelSpeed * Time.deltaTime, 0);
        if (transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        // �tk�z�s figyel�se
        if (other.gameObject.tag == "enemy1" || other.gameObject.tag == "enemy2" || other.gameObject.tag == "enemy3" || other.gameObject.tag == "enemy4" || other.gameObject.tag == "enemy5" || other.gameObject.tag == "enemy6" || other.gameObject.tag == "boss1" || other.gameObject.tag == "boss2" | other.gameObject.tag == "boss3")
        {
            Destroy(this.gameObject);
        }
    }

    public void UpgradeDamage(int extraDamage)
    {
        // Sebz�s n�vel�se
        damage += extraDamage;
    }

    public void UpgradeProjectileSpeed(int extraSpeed)
    {
        // L�ved�k sebess�g�nek n�vel�se
        travelSpeed += extraSpeed;
    }
}