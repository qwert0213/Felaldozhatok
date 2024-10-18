using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : EnemyAttack
{
    // Start is called before the first frame update
    public GameObject bomb;
    // Update is called once per frame
    public override void Shoot()
    {
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
