using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health;
    public PlayerAttack playerAttack;
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
    }
=======
    public AudioSource damageTaken;
>>>>>>> Stashed changes

    void Update()
    {
<<<<<<< Updated upstream
        if (health == 0)
        {
            Destroy(this.gameObject);

        }
=======
        playerAttack = GameObject.FindGameObjectWithTag("playerAttack").GetComponent<PlayerAttack>();
>>>>>>> Stashed changes
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerAttack")
        {
            health -= playerAttack.damage;
            damageTaken.Play();
            transform.position = new Vector3(Random.Range(-9,9), transform.position.y, 0);
        }
    }
   
}
