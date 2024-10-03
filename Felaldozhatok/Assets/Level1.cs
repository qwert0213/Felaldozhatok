using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public SpawningEnemy spawner;
    public EnemyManager enemyManager;
    public Control control;
    public List<int> level1Spawns;
    public AudioSource bossFight;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<SpawningEnemy>();
        control = GameObject.Find("Player").GetComponent<Control>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        spawner.maxEnemies = 7;
        level1Spawns = new List<int> {1,1,2,3,2,1,99};
        bossFight = GameObject.Find("BossFight").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.canSpawn)
        {
                if (level1Spawns[spawner.enemyCount] == 1)
                {
                    spawner.SpawnEnemy1();
                EnemySpawned();
            }
            else
            {
                if (level1Spawns[spawner.enemyCount] == 2)
                {
                    spawner.SpawnEnemy2();
                    EnemySpawned();
                }
                else
                {
                    if (level1Spawns[spawner.enemyCount] == 3)
                    {
                        spawner.SpawnEnemy3();
                        EnemySpawned();
                    }
                    else
                    {
                        if (level1Spawns[spawner.enemyCount] == 99 && enemyManager.enemiesKilled == spawner.maxEnemies - 1)
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
}