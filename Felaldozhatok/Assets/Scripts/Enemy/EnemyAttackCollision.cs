using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour
{
    void Update()
    {
        // Leesés figyelés
        if (transform.position.y < - 18)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Ütközés figyelés
        if (other.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }
}
