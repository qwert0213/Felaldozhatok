using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public GameObject player; // Referencia a játékosra
    private Control control; // A játékos vezérlése
    public PlayerCollision playerCollision; // A játékos életerejének kezelése
    public Text feedbackText; // Visszajelzés megjelenítése

    public void Start()
    {
        control = player.GetComponent<Control>();

        // Keressük meg a rocket GameObjectet a Player alatt
        GameObject rocket = GameObject.Find("rocket");
        if (rocket != null)
        {
            playerCollision = rocket.GetComponent<PlayerCollision>();
        }
        else
        {
            Debug.LogError("Rocket GameObject nem található!");
        }
    }

    // Sebesség fejlesztése
    public void UpgradeSpeed()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.movementSpeed += 5;
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Speed upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Támadás sebességének fejlesztése
    public void UpgradeAttack()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.attackRate -= 0.1f; // Csökkentjük az időt a támadások között
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Attack speed upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Lövedék sebességének növelése
    public void UpgradeProjectileSpeed()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.UpgradeProjectileSpeed(5); // Növeljük a lövedék sebességét
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Projectile speed upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Maximális életerő növelése
    public void UpgradeMaxHealth()
    {
        if (PlayerStats.instance.money >= 50)
        {
            playerCollision.UpgradeMaxHealth(1); // Növeljük a maximális életerőt
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Max health upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Sebzés növelése
    public void UpgradeDamage()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.UpgradeDamage(1); // Növeljük a sebzést
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Damage upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Kilépés az Upgrade Shopból
    public void ExitShop()
    {
        gameObject.SetActive(false); // Az Upgrade Shop bezárása
    }
}
