using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance; // Singleton referencia
    public int money = 0; // A j�t�kos p�nze

    void Awake()
    {
        // Singleton biztos�t�sa
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // P�nz n�vel�se
    public void AddMoney(int amount)
    {
        money += amount;
    }
}