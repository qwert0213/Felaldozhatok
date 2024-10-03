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
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();
        SetAttackRate();
        SetAttackSound();
    }

    // Update is called once per frame
    void Update()
    {
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
