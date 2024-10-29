using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public SpawningEnemy spawner;
    public EnemyManager enemyManager;
    public Control control;
    public List<int> spawns;
    public List<int> level1Spawns;
    public List<int> level2Spawns;
    public List<int> level3Spawns;
    public List<int> level4Spawns;
    public List<int> level5Spawns;
    public AudioSource bossFight;
    public int levelCounter = 0;
    public bool levelPlayable = false;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<SpawningEnemy>();
        control = GameObject.Find("Player").GetComponent<Control>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        level1Spawns = new List<int> { 1 };
        level2Spawns = new List<int> { 4, 4};
        level3Spawns = new List<int> { 4, 4 };
        level4Spawns = new List<int> { 4, 4 };
        level5Spawns = new List<int> { 4, 4 };
        spawns = new List<int> { };
        bossFight = GameObject.Find("BossFight").GetComponent<AudioSource>();

    }
    public void LevelSet()
    {
        if (levelCounter == 1)
        {
            spawns = level1Spawns;
            spawner.maxEnemies = level1Spawns.Count;
            spawner.ReportMaxEnemies();
        }
        if (levelCounter == 2)
        {
            spawns = level2Spawns;
            spawner.maxEnemies = level2Spawns.Count;
            spawner.ReportMaxEnemies();
        }
        if (levelCounter == 3)
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (spawner.canSpawn && levelPlayable)
        {
            if (spawns[spawner.enemyCount] == 1)
            {
                spawner.SpawnEnemy1();
                spawner.spawnRate = 3;
                EnemySpawned();
            }
            else
            {
                if (spawns[spawner.enemyCount] == 2)
                {
                    spawner.SpawnEnemy2();
                    EnemySpawned();
                }
                else
                {
                    if (spawns[spawner.enemyCount] == 3)
                    {
                        spawner.SpawnEnemy3();
                        EnemySpawned();
                    }
                    else
                    {
                        if (spawns[spawner.enemyCount] == 4)
                        {
                            spawner.SpawnAsteroid();
                            spawner.spawnRate = 0.5f;
                            EnemySpawned();
                        }
                        else
                        {
                            if (spawns[spawner.enemyCount] == 5)
                            {
                                spawner.SpawnWreck();
                                spawner.spawnRate = 0.5f;
                                EnemySpawned();
                            }
                            else
                            {
                                if (spawns[spawner.enemyCount] == 99 && enemyManager.enemiesKilled == spawner.maxEnemies - 1)
                                {
                                    bossFight.Play();
                                    spawner.SpawnBoss1();
                                    EnemySpawned();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void EnemySpawned()
    {
        spawner.enemyCount++;
        spawner.canSpawn = false;
        spawner.elapsedTime = 0;
    }
    public void StartLevel()
    {
        levelPlayable = true;
        levelCounter++;
        LevelSet();
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public SpawningEnemy spawner;
    public EnemyManager enemyManager;
    public Control control;
    public List<int> spawns;
    public AudioSource bossFight;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<SpawningEnemy>();
        control = GameObject.Find("Player").GetComponent<Control>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        spawner.maxEnemies = 7;
        spawns = new List<int> {1,1,2,3,2,1,99};
        bossFight = GameObject.Find("BossFight").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.canSpawn)
        {
                if (spawns[spawner.enemyCount] == 1)
                {
                    spawner.SpawnEnemy1();
                EnemySpawned();
            }
            else
            {
                if (spawns[spawner.enemyCount] == 2)
                {
                    spawner.SpawnEnemy2();
                    EnemySpawned();
                }
                else
                {
                    if (spawns[spawner.enemyCount] == 3)
                    {
                        spawner.SpawnEnemy3();
                        EnemySpawned();
                    }
                    else
                    {
                        if (spawns[spawner.enemyCount] == 99 && enemyManager.enemiesKilled == spawner.maxEnemies - 1)
                        {
                            bossFight.Play();
                            spawner.SpawnBoss1();
                            EnemySpawned();
                        }
                    }
                }
            }
        }
    }
    public void EnemySpawned() {
        spawner.enemyCount++;
        spawner.canSpawn = false;
        spawner.elapsedTime = 0;
    }
}*/