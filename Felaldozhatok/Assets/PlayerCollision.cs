<<<<<<< Updated upstream
﻿using System.Collections;
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
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Control control;
    public AudioSource damageTaken;
    public Text gameOver;
    public float wait = 0;
    public EnemyManager enemyManager;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        health = maxHealth = 3;
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
        playerStats = GameObject.Find("EnemyManager").GetComponent<PlayerStats>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            enemyManager.ModifyTxt();
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
            playerStats.AddScore(-20);
            health -= 1;
        }
        if (other.gameObject.tag == "wallLeft")
        {
            control.goLeft = false;
        }
        if (other.gameObject.tag == "wallRight")
        {
            control.goRight = false;
        }
    }

    // Maximális életerő növelése
    public void UpgradeMaxHealth(int extraHealth)
    {
        maxHealth += extraHealth;
        health = maxHealth; // Frissítjük az aktuális életerőt a maximálisra
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "wallLeft")
        {
            control.goLeft = true;
        }
        if (other.gameObject.tag == "wallRight")
        {
            control.goRight = true;
        }
    }
}
>>>>>>> Stashed changes
