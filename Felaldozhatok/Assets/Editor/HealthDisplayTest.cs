using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayTests
{
    private GameObject player;
    private PlayerCollision playerCollision;
    private HealthDisplay healthDisplay;
    private GameObject heartsParent;

    [SetUp]
    public void SetUp()
    {
        // Létrehozzuk a szükséges GameObject-eket
        player = new GameObject("Player");
        playerCollision = player.AddComponent<PlayerCollision>();
        playerCollision.health = 3; // Kezdő életerő
        playerCollision.maxHealth = 3; // Maximális életerő

        // Létrehozzuk a HealthDisplay GameObject-et
        healthDisplay = new GameObject("HealthDisplay").AddComponent<HealthDisplay>();

        // Létrehozzuk a szív prefab-et
        heartsParent = new GameObject("HeartsParent");
        healthDisplay.heartsParent = heartsParent.transform;

        // Létrehozzuk a szív prefab-et (egyszerű UI elem)
        GameObject heartPrefab = new GameObject("Heart");
        heartPrefab.AddComponent<Image>(); // Hozzáadunk egy Image komponenst

        healthDisplay.heartPrefab = heartPrefab;
        healthDisplay.playerCollision = playerCollision;

        // Inicializáljuk a HealthDisplay-t
        healthDisplay.Start();
    }

    [TearDown]
    public void TearDown()
    {
        // Töröljük a GameObject-eket
        Object.DestroyImmediate(player);
        Object.DestroyImmediate(healthDisplay.gameObject);
        Object.DestroyImmediate(heartsParent);
    }

    [Test]
    public void UpdateHearts_WhenHealthChanges_ShouldUpdateHeartCount()
    {
        // Act
        playerCollision.health = 2; // Csökkentjük az életerőt
        healthDisplay.UpdateHearts(); // Frissítjük a szíveket

        // Assert
        Assert.AreEqual(2, healthDisplay.hearts.Count); // Ellenőrizzük, hogy a szívek száma 2 legyen

        // Act
        playerCollision.health = 4; // Növeljük az életerőt
        healthDisplay.UpdateHearts(); // Frissítjük a szíveket

        // Assert
        Assert.AreEqual(4, healthDisplay.hearts.Count); // Ellenőrizzük, hogy a szívek száma 4 legyen
    }
}
