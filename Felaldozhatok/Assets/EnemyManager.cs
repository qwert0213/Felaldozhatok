using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Text missionText; // A felirat megjelenítéséhez
    public Text moneyText; // A pénz kijelzéséhez
    public GameObject upgradeShopUI; // Referencia az Upgrade Shop UI-ra
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
            StartCoroutine(MissionSuccessRoutine()); // Elindítjuk a küldetés sikerességét kezelő rutint
        }
    }

    // "Mission Accomplished" felirat megjelenítése 3 másodpercig, majd az Upgrade Shop megnyitása
    private IEnumerator MissionSuccessRoutine()
    {
        missionText.text = "Mission Accomplished!"; // Felirat beállítása
        yield return new WaitForSeconds(3); // Várunk 3 másodpercet
        missionText.text = ""; // Felirat eltüntetése

        OpenUpgradeShop(); // Upgrade Shop megnyitása
    }

    // "Upgrade Shop" UI megnyitása
    private void OpenUpgradeShop()
    {
        upgradeShopUI.SetActive(true); // Az Upgrade Shop UI aktiválása
    }

    // Update - minden képkockánál frissítjük a pénz kijelzést
    void Update()
    {
        moneyText.text = "Money: " + PlayerStats.instance.money;
    }
}
