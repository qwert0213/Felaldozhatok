﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health;
    public PlayerAttack playerAttack;
    public AudioSource damageTaken;
    public PlayerCollision playerCollision;
    public Control control;
    void Awake()
    {
        // Szükséges gameobjectek megkeresése
        playerCollision = GameObject.Find("rocket").GetComponent<PlayerCollision>();
    }

    void Update()
    {
        if (health <= 0)
        {
            // Ha az ellenség meghal, jelentjük az EnemyManager-nek
            EnemyManager.instance.EnemyKilled();
            Destroy(this.gameObject);
        }
        playerAttack = GameObject.FindGameObjectWithTag("playerAttack").GetComponent<PlayerAttack>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerAttack")
        {
            // Az ütköző lövedék PlayerAttack komponensének lekérése
            PlayerAttack currentAttack = other.gameObject.GetComponent<PlayerAttack>();
            health -= currentAttack.damage; // Az aktuális lövedék sebzésének levonása
            damageTaken.Play();
            transform.position = new Vector3(Random.Range(-9, 9), transform.position.y, 0);
        }
    }

}
