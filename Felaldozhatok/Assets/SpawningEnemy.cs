using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawningPosition : MonoBehaviour
{
    public GameObject enemy1;
    public int offset = 18;
    public float spawnRate = 3;
    public float elapsedTime = 2;
    public int health = 1;
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
            if (elapsedTime < spawnRate)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                SpawnEnemy();
                elapsedTime = 0;
            }
        }
    }
    public void SpawnEnemy()
    {
        float right = transform.position.x + offset;
        Instantiate(enemy1, new Vector3(Random.Range(-9, right), transform.position.y, 0), transform.rotation);
    }
    
}
