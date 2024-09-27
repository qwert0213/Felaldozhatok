using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public int movementSpeed = 15;
    public bool controllable = false;
    public GameObject playerAttack;
    public GameObject player;
    public float attackRate = 1;
    public float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controllable)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space) && attackRate < elapsedTime)
            {
                Instantiate(playerAttack, new Vector3(transform.position.x+3, transform.position.y+7, 0), transform.rotation);
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }

    }
}
