using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss2Attacks : EnemyAttack
{
    public GameObject trident;
    public GameObject candle;
    public int abilityCounter = 1;
    public PlayerCollision player;

    private void Awake()
    {
        player = GameObject.Find("rocket").GetComponent<PlayerCollision>();
    }
    public void Ability1()
    {
        // Ellens�g l�ved�kek gener�l�sa
        Instantiate(trident, new Vector3(player.transform.position.x, transform.position.y, 0), transform.rotation);
    }
    public void Ability2()
    {
        // Ellens�g l�ved�kek gener�l�sa
        for (int i = -10; i <= 0; i+=5)
        {
            Instantiate(candle, new Vector3(i, transform.position.y, 0), transform.rotation);
        }
    }
    public void Ability3()
    {
        // Ellens�g l�ved�kek gener�l�sa
        for (int i = 0; i <= 10; i+=5)
        {
            Instantiate(candle, new Vector3(i, transform.position.y, 0), transform.rotation);
        }
    }
    public override void Shoot()
    {
        // Ellens�g t�mad�s kiv�laszt�sa
        attackSound.Play();
        if (abilityCounter % 3 == 1)
        {
            Ability2();
        }
        else
        {
            if (abilityCounter % 5 == 1)
            {
                Ability3();
            }
            else
            {
                Ability1();
            }
        } 

        abilityCounter++;
    }
    public override void SetAttackRate()
    {
        attackRate = 1;
    }
    public override void SetAttackSound()
    {
        attackSound = GameObject.Find("SpellCast").GetComponent<AudioSource>();
    }
}
