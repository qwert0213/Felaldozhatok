using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Attack : EnemyAttack
{

    public GameObject disc;

    public override void Shoot()
    {
        // Ellenség lövedékek generálása
        for (int i = 0; i <= 2; i++)
        {
            GameObject enemyAttack = Instantiate(disc, new Vector3(transform.position.x - 3 + (3 * i), transform.position.y, 0), transform.rotation);
            attackSound.Play();
        }
    }

    public override void SetAttackRate()
    {
        attackRate = 1.5f;
    }
    public override void SetAttackSound()
    {
        attackSound = GameObject.Find("SpellCast").GetComponent<AudioSource>();
    }
}
