using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance; // Singleton referencia
    public int money = 0; // A játékos pénze
    public int score = 0;
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

    // Pénz növelése
    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
