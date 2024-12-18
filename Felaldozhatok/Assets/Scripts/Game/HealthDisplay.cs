﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Hozzáadva az UI elemekhez

public class HealthDisplay : MonoBehaviour
{
    public PlayerCollision playerCollision; // Hivatkozás a PlayerCollision scriptre
    public GameObject heartPrefab; // Szív prefab
    public Transform heartsParent; // HeartsContainer GameObject (UI elem)

    public List<GameObject> hearts = new List<GameObject>(); // A szívek tárolása

    public void Start()
    {
        UpdateHearts();
    }

    void Update()
    {
        // Csak akkor frissítjük a szíveket, ha a játékos életereje megváltozott
        if (hearts.Count != playerCollision.health)
        {
            UpdateHearts();
        }
    }

    public void UpdateHearts()
    {
        // A szívek frissítése a játékos életerejéhez igazodva
        // Ha több szív van, mint a jelenlegi életerő, akkor a lista legelső szívét töröljük
        if (hearts.Count > playerCollision.health)
        {
            int difference = hearts.Count - playerCollision.health;
            for (int i = 0; i < difference; i++)
            {
                // A legelső szív átlátszóságának csökkentése
                Image heartImage = hearts[0].GetComponent<Image>();
                heartImage.color = new Color(heartImage.color.r, heartImage.color.g, heartImage.color.b, 0); // Az alpha érték 0-ra állítása
                hearts.RemoveAt(0); // Eltávolítjuk a szívet a listából
            }
        }
        // Ha kevesebb szív van, mint a jelenlegi életerő, akkor új szíveket adunk hozzá
        else if (hearts.Count < playerCollision.health)
        {
            int difference = playerCollision.health - hearts.Count;
            for (int i = 0; i < difference; i++)
            {
                // Új szív létrehozása és hozzáadása a végére
                GameObject newHeart = Instantiate(heartPrefab, heartsParent);
                hearts.Add(newHeart);
            }
        }
    }
}
