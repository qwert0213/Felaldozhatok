using NUnit.Framework;
using UnityEngine;

public class PlayerStatsTests
{
    private PlayerStats playerStats;

    [SetUp]
    public void SetUp()
    {
        playerStats = new GameObject().AddComponent<PlayerStats>();
    }

    [Test]
    public void AddMoney_IncreasesMoneyCorrectly()
    {
        // Arrange
        int initialMoney = playerStats.money;
        int amountToAdd = 50;

        // Act
        playerStats.AddMoney(amountToAdd);

        // Assert
        Assert.AreEqual(initialMoney + amountToAdd, playerStats.money);
    }

    [Test]
    public void AddScore_IncreasesScoreCorrectly()
    {
        // Arrange
        int initialScore = playerStats.score;
        int scoreToAdd = 30;

        // Act
        playerStats.AddScore(scoreToAdd);

        // Assert
        Assert.AreEqual(initialScore + scoreToAdd, playerStats.score);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(playerStats.gameObject);
    }
}
