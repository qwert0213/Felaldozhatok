using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public int health;          // A játékos aktuális életereje
    public int maxHealth;       // A játékos maximális életereje
    public Control control;
    public AudioSource damageTaken;
    public Text gameOver;
    public float wait = 0;

    void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();
        health = maxHealth = 3; // Alapértelmezett maximális életerő
        damageTaken = gameObject.GetComponent<AudioSource>();
        gameOver.enabled = false;
    }

    void Update()
    {
        if (health <= 0)
        {
            control.controllable = false;
            gameOver.enabled = true;
            wait += Time.deltaTime;
            if (wait > 1)
            {
                GameObject rocket = GameObject.Find("Player");
                rocket.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyAttack")
        {
            damageTaken.Play();
            health -= 1;
            health = Mathf.Max(health, 0); // Biztosítja, hogy az életerő ne legyen negatív
        }
    }

    // Maximális életerő növelése
    public void UpgradeMaxHealth(int extraHealth)
    {
        maxHealth += extraHealth;
        health = maxHealth; // Frissítjük az aktuális életerőt a maximálisra
    }

    // Az egyéb OnTriggerExit kódok változatlanok maradnak
}
