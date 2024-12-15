using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    public GameObject enemy1; // Az ellenség prefab
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public GameObject asteroid1;
    public GameObject wreck1;
    public float spawnRate = 3; // Spawn sebessége másodpercenként
    public float elapsedTime = 2; // Elapsed time for spawning
    public Control control; // Referencia a játékos kontrolljára
    public int enemyCount =0; // Az eddig spawnolt ellenségek száma
    public bool canSpawn;
    public int maxEnemies;
    public EnemyManager enemyManager;

    void Start()
    {
        // Szükséges gameobjectek megkeresése
        control = GameObject.Find("Player").GetComponent<Control>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
    public void ReportMaxEnemies() {
        // Szint ellenségszámláló elindítása
        enemyManager.SetMaxEnemies(maxEnemies);
        enemyCount = 0;
    }
    void Update()
    {
        // Spawnolások közötti idő számolása
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
    // Enemy típusok spawnolása
    public void SpawnEnemy1()
    {
        SpawnNewEnemy(enemy1);
    }
    public void SpawnEnemy2()
    {
        SpawnNewEnemy(enemy2);
    }
    public void SpawnEnemy3()
    {
        SpawnNewEnemy(enemy3);
    }
    public void SpawnEnemy4()
    {
        SpawnNewEnemy(enemy4);
    }
    public void SpawnEnemy5()
    {
        SpawnNewEnemy(enemy5);
    }
    public void SpawnEnemy6()
    {
        SpawnNewEnemy(enemy6);
    }
    public void SpawnBoss1()
    {
        SpawnNewEnemy(boss1);
    }
    public void SpawnBoss2()
    {
        SpawnNewEnemy(boss2);
    }
    public void SpawnBoss3()
    {
        SpawnNewEnemy(boss3);
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
        // Ellenség spawnolása
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9, 9), transform.position.y, 0), transform.rotation);
    }
}
