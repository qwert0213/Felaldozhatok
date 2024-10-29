using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PlayerCollisionTest
{
    private GameObject player;
    private GameObject enemyProjectile;
    private PlayerCollision playerCollision;
    private AudioSource damageTakenAudio;

    [SetUp]
    public void SetUp()
    {
        // Létrehozzuk a játékos objektumot
        player = new GameObject("Player");
        playerCollision = player.AddComponent<PlayerCollision>();

        // Szükséges komponensek mockolása
        playerCollision.control = player.AddComponent<Control>();

        // EnemyManager és PlayerStats hozzáadása és inicializálása
        var enemyManagerObj = new GameObject("EnemyManager");
        playerCollision.enemyManager = enemyManagerObj.AddComponent<EnemyManager>();
        playerCollision.playerStats = enemyManagerObj.AddComponent<PlayerStats>();

        // Kezdeti életérték beállítása
        playerCollision.health = playerCollision.maxHealth = 3;

        // AudioSource hozzáadása és mockolása
        var damageAudioObj = new GameObject("Damage");
        damageTakenAudio = damageAudioObj.AddComponent<AudioSource>();
        playerCollision.damageTaken = damageTakenAudio;

        // GameOver UI Text beállítása
        //var gameOverTextObj = new GameObject("GameOverText");
        //playerCollision.gameOver = gameOverTextObj.AddComponent<Text>();
        //playerCollision.gameOver.enabled = false;  // Kezdetben inaktív

        // Létrehozzuk az ellenség lövedékét
        enemyProjectile = new GameObject("EnemyProjectile");
        enemyProjectile.tag = "enemyAttack";
        enemyProjectile.AddComponent<BoxCollider>();  // Hozzáadunk egy ütközést kezelő komponenst

        // Ütközési beállítások
        enemyProjectile.transform.position = player.transform.position;
    }

    [Test]
    public void PlayerTakesDamage_WhenHitByEnemyProjectile()
    {
        // Ellenőrizzük, hogy a kezdeti egészség helyes
        Assert.AreEqual(3, playerCollision.health);

        // Szimuláljuk a lövedék ütközését
        playerCollision.OnTriggerEnter(enemyProjectile.GetComponent<Collider>());

        // Ellenőrizzük, hogy az egészség csökkent-e 1-gyel
        Assert.AreEqual(2, playerCollision.health);
    }

    [TearDown]
    public void TearDown()
    {
        // Takarítás, hogy ne maradjanak felesleges objektumok
        Object.DestroyImmediate(player);
        Object.DestroyImmediate(enemyProjectile);
    }
}
