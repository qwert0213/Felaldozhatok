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
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
