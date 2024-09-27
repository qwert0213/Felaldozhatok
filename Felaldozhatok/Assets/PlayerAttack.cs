using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int travelSpeed = 10;
    public EnemyLogic enemyLogic;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyLogic = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + travelSpeed * Time.deltaTime, 0);
        if (transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
