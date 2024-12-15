using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    public RawImage background;
    public float x;
    public float y;
    void Update()
    {
        // Mozgó háttér
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x, y) * Time.deltaTime, background.uvRect.size);
    }
}
