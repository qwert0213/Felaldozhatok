using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance; // Singleton referencia
    public int money = 0; // A j�t�kos p�nze
    public int score = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddMoney(int amount)
    {   
        // P�nz n�vel�se
        money += amount;
    }

    public void AddScore(int scoreToAdd)
    {
        // Pont n�vel�se
        score += scoreToAdd;
        if (score < 0)
        {
            score = 0;
        }
    }
}
