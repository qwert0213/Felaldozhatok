using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Attack : EnemyAttack
{
    // Start is called before the first frame update
    public GameObject spell;
    // Update is called once per frame

    public override void Shoot()
    {
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
