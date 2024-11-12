using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayClick : MonoBehaviour
{
    public Button playButton;
    public Control control;
    public GameObject menu;
    public Level1 level1;
    // Start is called before the first frame update
    void Start()
    {
        level1 = GameObject.Find("Logic").GetComponent<Level1>();
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        control = GameObject.Find("Player").GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick() {
        menu.SetActive(false);
        control.controllable = true;
        level1.StartCoroutine(level1.StartLevel());
    }
}
