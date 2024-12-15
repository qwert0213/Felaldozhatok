using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Attack : EnemyAttack
{
    public GameObject fireball;

    public override void Shoot()
    {
        // Ellenség lövedékek generálása
        GameObject enemyAttack = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        attackSound.Play();
    }
   
    public override void SetAttackRate()
    {
        attackRate = 5;
    }
    public override void SetAttackSound()
    {
        attackSound = GameObject.Find("Spell").GetComponent<AudioSource>();
    }
}
