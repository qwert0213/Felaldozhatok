using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public int movementSpeed = 15;
    public bool controllable = false;
    public bool goLeft = true;
    public bool goRight = true;
    public GameObject playerAttack; // A l�ved�k prefabje
    public GameObject player;
    public float attackRate = 1;
    public float elapsedTime = 0;

    // L�ved�k sebess�g �s sebz�s fejleszt�s�nek nyomon k�vet�se
    public int upgradedProjectileSpeed = 0;
    public int upgradedDamage = 0;

    void Update()
    {
        // Ir�ny�t�s
        if (controllable)
        {
            if (Input.GetKey(KeyCode.A)&&goLeft)
            {
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D)&&goRight)
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space) && attackRate < elapsedTime)
            {
                // L�ved�k gener�l�sa
                GameObject newProjectile = Instantiate(playerAttack, new Vector3(transform.position.x + 3, transform.position.y + 7, 0), transform.rotation);
                // �tadjuk a fejleszt�seket a l�ved�knek
                PlayerAttack attackComponent = newProjectile.GetComponent<PlayerAttack>();
                attackComponent.UpgradeProjectileSpeed(upgradedProjectileSpeed);
                attackComponent.UpgradeDamage(upgradedDamage);
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }

    }

    // Fejleszt�sek kezel�se
    public void UpgradeProjectileSpeed(int extraSpeed)
    {
        upgradedProjectileSpeed += extraSpeed;
    }

    public void UpgradeDamage(int extraDamage)
    {
        upgradedDamage += extraDamage;
    }

}
