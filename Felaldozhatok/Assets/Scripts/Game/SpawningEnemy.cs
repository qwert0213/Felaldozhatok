using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    public GameObject enemy1; // Az ellenség prefab
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject boss1;
    public GameObject asteroid1;
    public GameObject wreck1;
    public float spawnRate = 3; // Spawn sebessége másodpercenként
    public float elapsedTime = 2; // Elapsed time for spawning
   // public int health = 1; // Az ellenség egészsége
    public Control control; // Referencia a játékos kontrolljára
    public int enemyCount =0; // Az eddig spawnolt ellenségek száma
    public bool canSpawn;
    public int maxEnemies;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<Control>();
        // A maximális ellenségek számának beállítása az EnemyManager-ben
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
    public void ReportMaxEnemies() {
        enemyManager.SetMaxEnemies(maxEnemies);
        enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < maxEnemies)
        {
            if (control.controllable)
            {
                if (elapsedTime < spawnRate)
                {
                    elapsedTime += Time.deltaTime;
                    canSpawn = false;
                }
                else
                {
                    canSpawn = true;
                    elapsedTime = 0;
                }
            }
        }
    }

    public void SpawnEnemy1()
    {
        SpawnNewEnemy(enemy1);
        // A RegisterEnemy() függvényt már nem használjuk itt
    }
    public void SpawnEnemy2()
    {
        SpawnNewEnemy(enemy2);
    }
    public void SpawnEnemy3()
    {
        SpawnNewEnemy(enemy3);
    }
    public void SpawnBoss1()
    {
        SpawnNewEnemy(boss1);
    }
    public void SpawnAsteroid()
    {
        SpawnNewEnemy(asteroid1);
    }
    public void SpawnWreck()
    {
        SpawnNewEnemy(wreck1);
    }
    public void SpawnNewEnemy(GameObject enemy) { 
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9, 9), transform.position.y, 0), transform.rotation);
    }
}
