using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public EnemyManager enemyManager;
    public float gravityScale = 2.0f; // Itt állítjuk be a gravitáció mértékét

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Alap Unity gravitációs erő alkalmazása egyéni szorzóval
        Vector3 customGravity = Physics.gravity * gravityScale;
        rb.AddForce(customGravity, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -18)
        {
            PlayerStats.instance.AddMoney(20);
            PlayerStats.instance.AddScore(20);
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            enemyManager.EnemyKilled();
            Destroy(this.gameObject);
        }
    }
}
