using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss3Attacks : EnemyAttack
{
    public GameObject web;
    public GameObject axe;
    public int abilityCounter = 1;
    public PlayerCollision player;

    private void Awake()
    {
        // Sz�ks�ges gameobjectek megkeres�se
        player = GameObject.Find("rocket").GetComponent<PlayerCollision>();
    }
    public void Ability1()
    {
        // Ellens�g l�ved�kek gener�l�sa
        int num = Random.Range(0, 5);
        for (int i = -10; i <= 10; i+=5)
        {
            if (i != (num-2) * 5)
            {
                Instantiate(web, new Vector3(i, transform.position.y, 0), transform.rotation);
            }
        }
    }
    public void Ability2()
    {
        // Ellens�g l�ved�kek gener�l�sa
        for (int i = 0; i <= 5; i ++)
        {
            Instantiate(axe, new Vector3(player.transform.position.x -6 + (3*i), transform.position.y, 0), transform.rotation);
        }
    }
    public override void Shoot()
    {
        // Ellens�g t�mad�s kiv�laszt�sa
        attackSound.Play();
        if (abilityCounter % 3 == 0)
        {
            Ability2();
        }
        else
        {
            Ability1();   
        }
        abilityCounter++;
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
