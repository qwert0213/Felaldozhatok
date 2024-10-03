using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.Windows;
using System;
using UnityEditor;
using UnityEngine.TextCore.Text;
public class EnemyManager : MonoBehaviour
{
    public Text missionText; // A felirat megjelenítéséhez
    public Text moneyText; // A pénz kijelzéséhez
    public int enemiesKilled = 0; // A megölt ellenségek száma
    private int maxEnemies; // A maximálisan spawnolható ellenségek száma
    public static EnemyManager instance; // Singleton referencia
    public PlayerStats playerStats;
    public UnityEngine.TextAsset scoreFile;
    public int scoreContent;
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
        if (enemiesKilled == maxEnemies) // Csak akkor írja ki, ha az összes spawnolt ellenség meghalt
        {
            MissionSuccess();
        }
    }


    // "Mission Successful" felirat kiírása
    public void MissionSuccess()
    {
        missionText.text = $"Mission Successful\nYour score: {playerStats.score}" ;
        ModifyTxt();
    }
    public void ModifyTxt()
    {
        if (playerStats.score > scoreContent)
        {
            System.IO.File.WriteAllText(AssetDatabase.GetAssetPath(scoreFile), playerStats.score.ToString());
            EditorUtility.SetDirty(scoreFile);
        }
    }

    private void Start()
    {
        playerStats = GameObject.Find("EnemyManager").GetComponent<PlayerStats>();
        scoreContent = int.Parse(scoreFile.text);
    }

    // Update - minden képkockánál frissítjük a pénz kijelzést
    void Update()
    {
        moneyText.text = "Money: " + PlayerStats.instance.money;
    }
}
