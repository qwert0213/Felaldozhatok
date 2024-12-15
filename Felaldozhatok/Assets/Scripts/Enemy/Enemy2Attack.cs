using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : EnemyAttack
{
    public GameObject bomb;
    public override void Shoot()
    {
        // Ellenség lövedékek generálása
        GameObject enemyAttack = Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        attackSound.Play();
    }
    public override void SetAttackRate()
    {
        attackRate = 2;
    }
    public override void SetAttackSound()
    {
        attackSound = GameObject.Find("Bomb").GetComponent<AudioSource>();
    }
}
