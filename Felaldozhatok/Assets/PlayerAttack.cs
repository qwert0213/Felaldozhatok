using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
<<<<<<< Updated upstream
    public int travelSpeed = 10; // A lövedék sebessége
    public int damage = 1;       // A lövedék alapértelmezett sebzése
    public EnemyLogic enemyLogic;

=======
    public int travelSpeed = 10;
    public int damage = 1;
    public EnemyLogic enemyLogic;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        enemyLogic = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        // A lövedék sebességének alkalmazása
        transform.position = new Vector3(transform.position.x, transform.position.y + travelSpeed * Time.deltaTime, 0);

        // Ha a lövedék elhagyja a képernyőt, megsemmisítjük
        if (transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject); // A lövedék megsemmisül, ha eltalálja az ellenséget
        }
    }

<<<<<<< Updated upstream
    // Sebzés növelése
=======
    // Sebz�s n�vel�se
>>>>>>> Stashed changes
    public void UpgradeDamage(int extraDamage)
    {
        damage += extraDamage;
    }

<<<<<<< Updated upstream
    // Lövedék sebességének növelése
=======
    // L�ved�k sebess�g�nek n�vel�se
>>>>>>> Stashed changes
    public void UpgradeProjectileSpeed(int extraSpeed)
    {
        travelSpeed += extraSpeed;
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
