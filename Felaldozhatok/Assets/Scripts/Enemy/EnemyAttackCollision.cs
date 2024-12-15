using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour
{
    void Update()
    {
        // Lees�s figyel�s
        if (transform.position.y < - 18)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // �tk�z�s figyel�s
        if (other.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }
}
