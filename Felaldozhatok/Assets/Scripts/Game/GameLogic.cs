using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour
{
    public Control control;
    void Start()
    {
        // Szükséges gameobjectek megkeresése
        control = GameObject.Find("Player").GetComponent<Control>();
        control.controllable = false;
    }


}
