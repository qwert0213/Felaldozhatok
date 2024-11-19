using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public GameObject player; // Referencia a játékosra
    public GameObject storypanel; // Referencia a story panelre
    private Control control; // A játékos vezérlése
    public PlayerCollision playerCollision; // A játékos életerejének kezelése
    public Text feedbackText; // Visszajelzés megjelenítése
    public Text charactername; // A karakternév megjelenítéséhez
    public Text message; // Az üzenet megjelenítéséhez
    public Level1 level1;

    public void Start()
    {
        control = player.GetComponent<Control>();
        level1 = GameObject.Find("Logic").GetComponent<Level1>();
        // Keressük meg a rocket GameObjectet a Player alatt
        GameObject rocket = GameObject.Find("rocket");
        if (rocket != null)
        {
            playerCollision = rocket.GetComponent<PlayerCollision>();
        }
        else
        {
            Debug.LogError("Rocket GameObject nem található!");
        }
    }

    // Sebesség fejlesztése
    public void UpgradeSpeed()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.movementSpeed += 5;
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Speed upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Támadás sebességének fejlesztése
    public void UpgradeAttack()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.attackRate -= 0.1f; // Csökkentjük az időt a támadások között
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Attack speed upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Lövedék sebességének növelése
    public void UpgradeProjectileSpeed()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.UpgradeProjectileSpeed(5); // Növeljük a lövedék sebességét
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Projectile speed upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Maximális életerő növelése
    public void UpgradeMaxHealth()
    {
        if (PlayerStats.instance.money >= 50)
        {
            playerCollision.UpgradeMaxHealth(1); // Növeljük a maximális életerőt
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Max health upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Sebzés növelése
    public void UpgradeDamage()
    {
        if (PlayerStats.instance.money >= 50)
        {
            control.UpgradeDamage(1); // Növeljük a sebzést
            PlayerStats.instance.money -= 50;
            feedbackText.text = "Damage upgraded!";
        }
        else
        {
            feedbackText.text = "Not enough money!";
        }
    }

    // Kilépés az Upgrade Shopból
    public IEnumerator ExitShop()
    {
        gameObject.SetActive(false); // Az Upgrade Shop bezárása
        if (level1.levelCounter == 1) { yield return MissionBrief2(); }
        else if (level1.levelCounter == 2) { yield return MissionBrief3(); }
        else if (level1.levelCounter == 3) { yield return MissionBrief4(); }
        else { yield return MissionBrief5(); }
        level1.StartLevel();
    }

    public IEnumerator MissionBrief2()
    {
        storypanel.SetActive(true); // Az story panel aktiválása
        message.text = "Figyelem! Nagy koncentrációjú idegen objektumok észlelve! Kitérő manőverekre felkészülni!";
        charactername.text = "Rendszerüzenet";
        // Várakozás az Enter gomb lenyomására
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        storypanel.SetActive(false); // Az story panel deaktiválása
    }
    public IEnumerator MissionBrief3()
    {
        storypanel.SetActive(true); // Az story panel aktiválása
        message.text = "Itt Winters hadnagy. Orion, a tudósok kielemezték az Erebus Állomáson talált adatokat, és valami egészen döbbenetesre bukkantunk. Úgy tűnik, az emberiség a múltban kifejlesztett egy bolygótörő fegyvert – egy olyan eszközt, ami képes teljes planétákat megsemmisíteni. Az okok, hogy miért merült feledésbe, egyelőre homályosak, de egy dolog világos: az Onyxok most valahogy tudomást szereztek róla, és talán ezért kezdték el a támadásaikat. Nem engedhetjük meg, hogy ez a fegyver a kezükbe kerüljön. Orion, tudod mit kell tenned. Winters, vége.";
        charactername.text = "Winters hadnagy";
        // Várakozás az Enter gomb lenyomására
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        storypanel.SetActive(false); // Az story panel deaktiválása
    }
    public IEnumerator MissionBrief4()
    {
        storypanel.SetActive(true); // Az story panel aktiválása
        message.text = "Figyelem! Nagy koncentrációjú idegen objektumok észlelve! Kitérő manőverekre felkészülni!";
        charactername.text = "Rendszerüzenet";
        // Várakozás az Enter gomb lenyomására
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        storypanel.SetActive(false); // Az story panel deaktiválása
    }
    public IEnumerator MissionBrief5()
    {
        storypanel.SetActive(true); // Az story panel aktiválása
        message.text = "Itt Winters hadnagy. Orion, figyelj, a helyzet drámai fordulatot vett. Felderítőink jelentették, hogy az Onyxok fő flottája hatalmas ellentámadásra készül, és az Erebus Állomást vették célba. Ha sikerül felmenteniük a pozícióikat, az emberiség szinte biztosan elveszíti a csatát. Egyetlen esélyünk, ha megakadályozod, hogy elérjék az állomást. Vedd célba a flottát, semmisítsd meg az erősítéseiket, és biztosítsd, hogy az Erebus körüli térség a mi irányításunk alatt maradjon. Tudd, hogy az egész galaxis sorsa rajtad múlik. Winters, vége.";
        charactername.text = "Winters hadnagy";
        // Várakozás az Enter gomb lenyomására
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        storypanel.SetActive(false); // Az story panel deaktiválása
    }
}
