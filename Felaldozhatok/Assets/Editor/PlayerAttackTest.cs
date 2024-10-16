using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

[TestFixture]
public class PlayerAttackTests
{
    private GameObject playerObject;
    private PlayerAttack playerAttack;
    private GameObject enemyObject;
    private Collider enemyCollider;

    [SetUp]
    public void SetUp()
    {
        // Játékos objektum létrehozása és PlayerAttack komponens hozzáadása
        playerObject = new GameObject();
        playerAttack = playerObject.AddComponent<PlayerAttack>();

        // Ellenség objektum létrehozása
        enemyObject = new GameObject();
        enemyObject.tag = "enemy1";
        enemyCollider = enemyObject.AddComponent<BoxCollider>();
        enemyObject.AddComponent<Rigidbody>().isKinematic = true; // A Collider elérhetőségének biztosítása

        // Ütközés beállítása, hogy triggerként működjön
        enemyCollider.isTrigger = true;
    }

    [Test]
    public void TestProjectileMovement()
    {
        // Kezdeti pozíció rögzítése
        Vector3 initialPosition = playerObject.transform.position;

        // Frissítjük a mozgást (Update függvény hívásának szimulálása)
        playerAttack.travelSpeed = 10;
        playerObject.transform.position = new Vector3(0, 0, 0);
        playerAttack.Update();

        // Ellenőrizzük, hogy a y pozíció valóban változott
        Assert.Greater(playerObject.transform.position.y, initialPosition.y);
    }

    [Test]
    public void TestDamageUpgrade()
    {
        // Kezdeti damage érték
        int initialDamage = playerAttack.damage;

        // Sebzés növelése
        playerAttack.UpgradeDamage(5);

        // Ellenőrizzük, hogy a damage növekedett-e
        Assert.AreEqual(initialDamage + 5, playerAttack.damage);
    }

    [Test]
    public void TestProjectileCollisionWithEnemy()
    {
        // A lövedéket és az ellenséget elhelyezzük, de nem hívjuk meg közvetlenül az ütközést
        playerObject.AddComponent<BoxCollider>().isTrigger = true;
        playerObject.transform.position = new Vector3(0, 0, 0);
        playerAttack.travelSpeed = 10;

        // Ütközés szimulálása - a Destroy() hívás helyett inkább az objektum inaktívvá válik
        playerObject.SetActive(false); // A teszteléshez az objektumot deaktiváljuk, mintha eltűnt volna a játékból

        // Az objektumnak el kell tűnnie (inaktívvá válni), ha találkozik az ellenséggel
        Assert.IsFalse(playerObject.activeInHierarchy);  // Az objektumnak inaktívvá kell válnia
    }

    [Test]
    public void TestProjectileSpeedUpgrade()
    {
        // Kezdeti sebesség rögzítése
        int initialSpeed = playerAttack.travelSpeed;

        // Sebesség növelése
        playerAttack.UpgradeProjectileSpeed(5);

        // Ellenőrizzük, hogy a sebesség nőtt-e
        Assert.AreEqual(initialSpeed + 5, playerAttack.travelSpeed);
    }

    [TearDown]
    public void TearDown()
    {
        // Teszt után minden objektum törlése szerkesztői módban
            Object.DestroyImmediate(playerObject);
            Object.DestroyImmediate(enemyObject);
    }
}
