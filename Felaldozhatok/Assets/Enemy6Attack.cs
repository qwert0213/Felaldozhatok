using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy6Attack : EnemyAttack
{
    // Start is called before the first frame update

    public GameObject disc;
    // Update is called once per frame

    public override void Shoot()
    {
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
