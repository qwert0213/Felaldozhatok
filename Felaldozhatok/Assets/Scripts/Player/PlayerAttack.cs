using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int travelSpeed = 10;
    public int damage = 1;
    public EnemyLogic enemyLogic;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + travelSpeed * Time.deltaTime, 0);
        if (transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy1" || other.gameObject.tag == "enemy2" || other.gameObject.tag == "enemy3" || other.gameObject.tag == "boss1" || other.gameObject.tag == "boss2" | other.gameObject.tag == "boss3")
        {
            Destroy(this.gameObject);
        }
    }

    // Sebzés növelése
    public void UpgradeDamage(int extraDamage)
    {
        damage += extraDamage;
    }

    // Lövedék sebességének növelése
    public void UpgradeProjectileSpeed(int extraSpeed)
    {
        travelSpeed += extraSpeed;
    }
}