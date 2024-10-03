using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public int movementSpeed = 15;
    public bool controllable = false;
    public bool goLeft = true;
    public bool goRight = true;
<<<<<<< Updated upstream
    public GameObject playerAttack;  // A lövedék prefabje
=======
    public GameObject playerAttack; // A lövedék prefabje
>>>>>>> Stashed changes
    public GameObject player;
    public float attackRate = 1;
    public float elapsedTime = 0;

    // Lövedék sebesség és sebzés fejlesztésének nyomon követése
    private int upgradedProjectileSpeed = 0;
    private int upgradedDamage = 0;

<<<<<<< Updated upstream
=======
    // Start is called before the first frame update
>>>>>>> Stashed changes
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controllable)
        {
            if (Input.GetKey(KeyCode.A) && goLeft)
            {
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && goRight)
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space) && attackRate < elapsedTime)
            {
                GameObject newProjectile = Instantiate(playerAttack, new Vector3(transform.position.x + 3, transform.position.y + 7, 0), transform.rotation);
<<<<<<< Updated upstream
                
=======

>>>>>>> Stashed changes
                // Átadjuk a fejlesztéseket a lövedéknek
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

    // Fejlesztések kezelése
    public void UpgradeProjectileSpeed(int extraSpeed)
    {
        upgradedProjectileSpeed += extraSpeed;
    }

    public void UpgradeDamage(int extraDamage)
    {
        upgradedDamage += extraDamage;
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
}
