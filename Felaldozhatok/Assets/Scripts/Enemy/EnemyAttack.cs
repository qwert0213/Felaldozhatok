using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float elapsedTime = 0;
    public int travelSpeed;
    public float attackRate;
    public Control control;
    public AudioSource attackSound;
    void Start()
    {
        // Szükséges gameobjectek megkeresése, adatok beállítása
        control = GameObject.Find("Player").GetComponent<Control>();
        SetAttackRate();
        SetAttackSound();
    }
    void Update()
    {
        // Lövési idõ számolása
        if (control.controllable)
        {
            if (elapsedTime < attackRate)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Shoot();
                elapsedTime = 0;
            }
        }
    }
    public virtual void Shoot() { }
    public virtual void SetAttackRate() { }
    public virtual void SetAttackSound() { }
}
