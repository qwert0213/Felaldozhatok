using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health = 1;
    public PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerAttack")
        {
            health -= playerAttack.damage;
        }
    }
   
}
