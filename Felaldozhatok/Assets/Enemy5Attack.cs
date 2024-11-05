using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Attack : EnemyAttack
{
    // Start is called before the first frame update

    public GameObject syringe;
    // Update is called once per frame

    public override void Shoot()
    {
        int num = Random.Range(0, 3);
        for (int i = -9; i <= 9; i += 9)
        {
            if (i != (num - 1) * 9)
            {
                GameObject enemyAttack = Instantiate(syringe, new Vector3(i, transform.position.y, 0), transform.rotation);
                attackSound.Play();
            }
        }

    }

    public override void SetAttackRate()
    {
        attackRate = 3;
    }
    public override void SetAttackSound()
    {
        attackSound = GameObject.Find("SpellCast").GetComponent<AudioSource>();
    }
}
