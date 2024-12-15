using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Attack : EnemyAttack
{
    public GameObject spell;
    public override void Shoot()
    {
        // Ellenség lövedékek generálása
        GameObject enemyAttack = Instantiate(spell, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        attackSound.Play();
    }
    public override void SetAttackRate()
    {
        attackRate = 3/2;
    }
    public override void SetAttackSound()
    {
        attackSound = GameObject.Find("SpellCast").GetComponent<AudioSource>();
    }
}
