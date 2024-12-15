using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1Attacks : EnemyAttack
{
    public GameObject spell;
    public GameObject spellBook;
    public int abilityCounter = 1;

    public void Ability1()
    {
        // Ellens�g l�ved�kek gener�l�sa
        for (int i = 0; i <= 2; i++)
        {
            Instantiate(spell, new Vector3(transform.position.x - 3 + (3 * i), transform.position.y, 0), transform.rotation);
        }
    }
    public void Ability2()
    {
        // Ellens�g l�ved�kek gener�l�sa
        for (int i = -10; i <= 10; i+=5)
        {
            Instantiate(spellBook, new Vector3(i, transform.position.y, 0), transform.rotation);
        }
    }
    public override void Shoot()
    {
        // Ellens�g t�mad�s kiv�laszt�sa
        attackSound.Play();
        if (abilityCounter % 2 == 0)
        {
            Ability1();
        }
        if (abilityCounter % 2 == 1)
        {
            Ability2();
        }
        abilityCounter++;
    }
    public override void SetAttackRate()
    {
        attackRate = 2;
    }
    public override void SetAttackSound() { 
        attackSound = GameObject.Find("SpellCast").GetComponent<AudioSource>();
    }
}
