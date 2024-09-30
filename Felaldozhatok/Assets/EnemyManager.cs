using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Text missionText; // A felirat megjelenítéséhez
    public Text moneyText; // A pénz kijelzéséhez
    private int enemiesKilled = 0; // A megölt ellenségek száma
    private int maxEnemies; // A maximálisan spawnolható ellenségek száma
    public static EnemyManager instance; // Singleton referencia

    void Awake()
    {
        // Singleton biztosítása
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // A maximális ellenségszám beállítása (a SpawningEnemy.cs-ből hívjuk meg)
    public void SetMaxEnemies(int max)
    {
        maxEnemies = max;
    }

    // Az ellenségek halálának kezelése
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled >= maxEnemies) // Csak akkor írja ki, ha az összes spawnolt ellenség meghalt
        {
            MissionSuccess();
        }
    }

    // "Mission Successful" felirat kiírása
    void MissionSuccess()
    {
        missionText.text = "Mission Successful";
    }

    // Update - minden képkockánál frissítjük a pénz kijelzést
    void Update()
    {
        moneyText.text = "Money: " + PlayerStats.instance.money;
    }
}
