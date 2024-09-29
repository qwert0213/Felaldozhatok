using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    public GameObject enemy1; // Az ellenség prefab
    public int offset = 18; // A spawn pozíció offsetje
    public float spawnRate = 3; // Spawn sebessége másodpercenként
    public float elapsedTime = 2; // Elapsed time for spawning
    public int health = 1; // Az ellenség egészsége
    public Control control; // Referencia a játékos kontrolljára
    private int enemyCount = 0; // Az eddig spawnolt ellenségek száma
    public int maxEnemies = 10; // Maximális spawnolható ellenségek száma

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();

        // A maximális ellenségek számának beállítása az EnemyManager-ben
        EnemyManager.instance.SetMaxEnemies(maxEnemies);
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
            else if (enemyCount < maxEnemies) // Csak akkor spawnolj, ha az ellenségek száma kevesebb mint maxEnemies
            {
                SpawnEnemy();
                elapsedTime = 0;
            }
        }
    }

    public void SpawnEnemy()
    {
        float right = transform.position.x + offset;
        GameObject newEnemy = Instantiate(enemy1, new Vector3(Random.Range(-9, right), transform.position.y, 0), transform.rotation);
        enemyCount++; // Növeld az ellenségek számát

        // A RegisterEnemy() függvényt már nem használjuk itt
    }
}
