using System;
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
    public GameObject gameOver;
    public float wait = 0;
    public EnemyManager enemyManager;
    public PlayerStats playerStats;
    void Start()
    {
        // Szükséges gameobjectek megkeresése
        control = GameObject.Find("Player").GetComponent<Control>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        health = maxHealth = 3;
        damageTaken = GameObject.Find("Damage").GetComponent<AudioSource>();
        playerStats = GameObject.Find("EnemyManager").GetComponent<PlayerStats>();
        gameOver.SetActive(false);
    }
    void Update()
    {
        // Megsemmisülés figyelése
        if (health <= 0)
        {
            enemyManager.ModifyTxt();
            gameOver.SetActive(true);
            control.controllable = false;
            wait += Time.deltaTime;
            if (wait > 1)
            {
                GameObject rocket = GameObject.Find("Player");
                rocket.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // Űrhajó megsebződése
        if (other.gameObject.tag == "enemyAttack")
        {
            damageTaken.Play();
            playerStats.AddScore(-20);
            health -= 1;
        }
        if (other.gameObject.tag == "asteroid")
        {
            damageTaken.Play();
            playerStats.AddScore(-20);
            health -= 1;
        }
        if (other.gameObject.tag == "wreck")
        {
            damageTaken.Play();
            playerStats.AddScore(-20);
            health -= 1;
        }
        // Képernyő széli falak figyelése
        if (other.gameObject.tag == "wallLeft")
        {
            control.goLeft = false;
        }
        if (other.gameObject.tag == "wallRight")
        {
            control.goRight = false;
        }
    }


    public void UpgradeMaxHealth(int extraHealth)
    {   
        // Maximális életerő növelése
        maxHealth += extraHealth;
        health = maxHealth; // Frissítjük az aktuális életerőt a maximálisra
    }

    private void OnTriggerExit(Collider other)
    {
        // Képernyő széli falak figyelése
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
