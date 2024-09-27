using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float elapsedTime = 0;
    public float attackRate = 5;
    public GameObject fireball;
    public float bulletSize = 1/2;
    public Control control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();
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
    public void Shoot()
    {
        float right = transform.position.x;
        GameObject enemyAttack = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }


}
