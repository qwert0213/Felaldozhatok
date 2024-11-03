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
using Unity.VisualScripting;
public class EnemyManager : MonoBehaviour
{
    public Text missionText; // A felirat megjelenítéséhez
    public Text gameCompleteText; 
    public Text moneyText; // A pénz kijelzéséhez
    public GameObject upgradeShopUI; // Referencia az Upgrade Shop UI-ra
    public int enemiesKilled = 0; // A megölt ellenségek száma
    private int maxEnemies; // A maximálisan spawnolható ellenségek száma
    public static EnemyManager instance; // Singleton referencia
    public PlayerStats playerStats;
    public UnityEngine.TextAsset scoreFile;
    public int scoreContent;
    public Level1 level1;
    public PlayerCollision playerCollision;
    
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
        enemiesKilled = 0;
    }

    // Az ellenségek halálának kezelése
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == maxEnemies && playerCollision.health > 0) // Csak akkor írja ki, ha az összes spawnolt ellenség meghalt
        {
            if (level1.levelCounter == 5)
            {
                ModifyTxt();
                if (scoreContent < playerStats.score)
                {
                    gameCompleteText.text = $"Victory Royale!\nNew high score: {playerStats.score}\nCongratulations!";
                }
                else
                if (scoreContent == playerStats.score)
                {
                    gameCompleteText.text = $"Victory Royale!\nYou hit your last high score: {playerStats.score}";
                }
                else
                {
                    gameCompleteText.text = $"Victory Royale!\nYour score: {playerStats.score}\nHigh score: {scoreContent}\nTry harder next time.";
                }
            }
            else
            {
                StartCoroutine(MissionSuccessRoutine()); // Elindítjuk a küldetés sikerességét kezelő rutint
            }
            
        }
    }


    // "Mission Accomplished" felirat megjelenítése 3 másodpercig, majd az Upgrade Shop megnyitása
    private IEnumerator MissionSuccessRoutine()
    {
        missionText.text = $"Mission Successful\nYour score: {playerStats.score}" ;
        ModifyTxt();
        yield return new WaitForSeconds(3); // Várunk 3 másodpercet
        missionText.text = ""; // Felirat eltüntetése
        level1.levelPlayable = false;
        enemiesKilled = 0;
        OpenUpgradeShop(); // Upgrade Shop megnyitása
    }

    // "Upgrade Shop" UI megnyitása
    private void OpenUpgradeShop()
    {
        upgradeShopUI.SetActive(true); // Az Upgrade Shop UI aktiválása
    }

    public void ModifyTxt()
    {
        // A fájl elérési útja a buildelt játékban
        string filePath = Application.dataPath + "/Resources/score.txt";

        if (playerStats.score > scoreContent)
        {
            // Írjuk át a fájlt, ha a játékos pontszáma nagyobb, mint az aktuális tartalom
            System.IO.File.WriteAllText(filePath, playerStats.score.ToString());
        }
    }

    private void Start()
    {
        playerStats = GameObject.Find("EnemyManager").GetComponent<PlayerStats>();
        level1 = GameObject.Find("Logic").GetComponent<Level1>();
        playerCollision = GameObject.Find("rocket").GetComponent<PlayerCollision>();
    }

    // Update - minden képkockánál frissítjük a pénz kijelzést
    void Update()
    {
        moneyText.text = "Money: " + PlayerStats.instance.money;
        scoreContent = int.Parse(scoreFile.text);
    }
}
