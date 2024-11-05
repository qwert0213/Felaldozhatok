using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Attack : EnemyAttack
{
    // Start is called before the first frame update

    public GameObject mushroom;
    // Update is called once per frame

    public override void Shoot()
    {
        int num = Random.Range(0, 5);
        int num2 = Random.Range(0, 5);
        for (int i = -10; i <= 10; i += 5)
        {
            if (i == (num - 2) * 5)
            {
                GameObject enemyAttack = Instantiate(mushroom, new Vector3(i, transform.position.y, 0), transform.rotation);
                attackSound.Play();
            }
            if (i == (num2 - 2) * 5)
            {
                GameObject enemyAttack = Instantiate(mushroom, new Vector3(i, transform.position.y, 0), transform.rotation);
                attackSound.Play();
            }
        }
    }

    public override void SetAttackRate()
    {
        attackRate = 1.5f;
    }
    public override void SetAttackSound()
    {
        attackSound = GameObject.Find("Spell").GetComponent<AudioSource>();
    }
}
