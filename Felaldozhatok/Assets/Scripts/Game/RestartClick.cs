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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        level1 = GameObject.Find("Logic").GetComponent<Level1>();
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        control = GameObject.Find("Player").GetComponent<Control>();
        playerCollision = GameObject.Find("rocket").GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        menu.SetActive(false);
        playerCollision.health = 3;
        level1.levelCounter -= 1;
        level1.StartLevel();
        control.controllable = true;
        player.transform.position = new Vector3(-3, -19, 0);
        player.SetActive(true);
    }
}
