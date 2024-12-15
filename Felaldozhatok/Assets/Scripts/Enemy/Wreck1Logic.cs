using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckCollision : MonoBehaviour
{
    public EnemyManager enemyManager;
    public float gravityScale = 2.0f; // Itt állítjuk be a gravitáció mértékét

    private Rigidbody rb;
    void Start()
    {
        // Szükséges gameobjectek megkeresése
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Alap Unity gravitációs erő alkalmazása egyéni szorzóval
        Vector3 customGravity = Physics.gravity * gravityScale;
        rb.AddForce(customGravity, ForceMode.Acceleration);
    }
    void Update()
    {
        // 'Leesés' figyelés
        if (transform.position.y < -18)
        {
            PlayerStats.instance.AddMoney(10);
            PlayerStats.instance.AddScore(10);
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Ütközés figyelés
        if (other.gameObject.tag == "player")
        {
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
