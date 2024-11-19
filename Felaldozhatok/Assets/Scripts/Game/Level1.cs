using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    public SpawningEnemy spawner;
    public EnemyManager enemyManager;
    public Control control;
    public GameObject introtext;
    public GameObject storypanel;
    public Text charactername; // A karakternév megjelenítéséhez
    public Text message; // Az üzenet megjelenítéséhez
    public List<int> spawns;
    public List<int> level1Spawns;
    public List<int> level2Spawns;
    public List<int> level3Spawns;
    public List<int> level4Spawns;
    public List<int> level5Spawns;
    public List<List<int>> spawn;
    public AudioSource bossFight;
    public int levelCounter = 0;
    public bool levelPlayable = false;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<SpawningEnemy>();
        control = GameObject.Find("Player").GetComponent<Control>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        level1Spawns = new List<int> { 1, 6, 2, 1, 2, 6, 1, 99 };
        level2Spawns = new List<int> { 11,11,11,11,11,11,11,11};
        level3Spawns = new List<int> { 1, 4, 4, 3, 4, 1, 3, 4, 199 };
        level4Spawns = new List<int> { 12,12,12,12,12,12,12,12,12};
        level5Spawns = new List<int> { 5, 3, 2, 5, 2, 5, 5, 3, 299 };
        spawn = new List<List<int>> { level1Spawns, level2Spawns, level3Spawns, level4Spawns, level5Spawns };
        spawns = new List<int> { };
        bossFight = GameObject.Find("BossFight").GetComponent<AudioSource>();

    }
    public void LevelSet()
    {
        spawns = spawn[levelCounter-1];
        spawner.maxEnemies = spawns.Count;
        spawner.ReportMaxEnemies();
    }
    // Update is called once per frame
    void Update()
    {
        if (spawner.canSpawn && levelPlayable && spawner.enemyCount != spawns.Count)
        {
            if (spawns[spawner.enemyCount] == 1)
            {
                spawner.SpawnEnemy1();
                spawner.spawnRate = 1.5f;
                EnemySpawned();
            }
            else
            {
                if (spawns[spawner.enemyCount] == 2)
                {
                    spawner.SpawnEnemy2();
                    spawner.spawnRate = 2;
                    EnemySpawned();
                }
                else
                {
                    if (spawns[spawner.enemyCount] == 3)
                    {
                        spawner.SpawnEnemy3();
                        spawner.spawnRate = 1.5f;
                        EnemySpawned();
                    }
                    else
                    {
                        if (spawns[spawner.enemyCount] == 4)
                        {
                            spawner.SpawnEnemy4();
                            spawner.spawnRate = 1;
                            EnemySpawned();
                        }
                        else
                        {
                            if (spawns[spawner.enemyCount] == 5)
                            {
                                spawner.SpawnEnemy5();
                                spawner.spawnRate = 1;
                                EnemySpawned();
                            }
                            else
                            {
                                if (spawns[spawner.enemyCount] == 6)
                                {
                                    spawner.SpawnEnemy6();
                                    spawner.spawnRate = 1;
                                    EnemySpawned();
                                }
                                else
                                {
                                    if (spawns[spawner.enemyCount] == 11)
                                    {
                                        spawner.SpawnAsteroid();
                                        spawner.spawnRate = 0.5f;
                                        EnemySpawned();
                                    }
                                    else
                                    {
                                        if (spawns[spawner.enemyCount] == 12)
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
                                                spawner.spawnRate = 1;
                                                spawner.SpawnBoss1();
                                                EnemySpawned();
                                            }
                                            else
                                            {
                                                if (spawns[spawner.enemyCount] == 199 && enemyManager.enemiesKilled == spawner.maxEnemies - 1)
                                                {
                                                    bossFight.Play();
                                                    spawner.spawnRate = 1;
                                                    spawner.SpawnBoss2();
                                                    EnemySpawned();
                                                }
                                                else
                                                {
                                                    if (spawns[spawner.enemyCount] == 299 && enemyManager.enemiesKilled == spawner.maxEnemies - 1)
                                                    {
                                                        bossFight.Play();
                                                        spawner.spawnRate = 1;
                                                        spawner.SpawnBoss3();
                                                        EnemySpawned();
                                                    }
                                                }
                                            }

                                        }
                                    }
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
    public IEnumerator StartLevel()
    {
        if (levelCounter == 0) { introtext.SetActive(true); } // Az intro szöveg aktiválása

        // Várakozás az Enter gomb lenyomására
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        introtext.SetActive(false); // Az intro szöveg deaktiválása
        yield return new WaitForSeconds(0.1f); // Várunk egy kicsit
        yield return MissionBrief1();
        levelPlayable = true;
        levelCounter++;
        LevelSet();
    }

    public IEnumerator MissionBrief1()
    {
        storypanel.SetActive(true); // Az story panel aktiválása
        message.text = "Itt Winters hadnagy a főparancsnokságról. Orion, figyelj, ez fontos. Nemrég elfogtunk egy rövid, kódolt adást az Onyxoktól. Az üzenet töredékes volt, de sikerült kihámozni belőle valami érdekeset. Úgy tűnik, koordinátákat küldtek a műveleti pontukhoz. Még nem tudjuk, pontosan mi vár ott, de nem szeretnénk, ha meglepnének minket. Te vagy az egyetlen, akiben teljesen megbízom ehhez a feladathoz. Menj a megadott koordinátákra, derítsd ki, mit terveznek, és jelents vissza, amint lehet. Tudom, hogy rádbízhatjuk ezt. Winters, vége.";
        charactername.text = "Winters hadnagy";
        // Várakozás az Enter gomb lenyomására
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        storypanel.SetActive(false); // Az story panel deaktiválása
    }

}