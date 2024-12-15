using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RestartClick : MonoBehaviour
{
    public Button restartButton;
    public Control control;
    public GameObject menu;
    public Level1 level1;
    public PlayerCollision playerCollision;
    public GameObject player;
    void Start()
    {
        // Sz�ks�ges gameobjectek megkeres�se
        player = GameObject.Find("Player");
        level1 = GameObject.Find("Logic").GetComponent<Level1>();
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        control = GameObject.Find("Player").GetComponent<Control>();
        playerCollision = GameObject.Find("rocket").GetComponent<PlayerCollision>();
    }

    public void OnClick()
    {
        // P�lya �jraind�t�s
        menu.SetActive(false);
        playerCollision.health = playerCollision.maxHealth;
        level1.levelCounter -= 1;
        level1.RestartLevel();
        control.controllable = true;
        player.transform.position = new Vector3(-3, -19, 0);
        player.SetActive(true);
    }
}
