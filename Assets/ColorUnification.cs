using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUnification : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] unifiedSprites;
    Color reservedColor;

    void Start()
    {
        reservedColor = unifiedSprites[0].color;
    }

    // Update is called once per frame
    void Update()
    {

        float r = reservedColor.r;
        float g = reservedColor.g;
        float b = reservedColor.b;
        foreach (SpriteRenderer sprite in unifiedSprites)
        {
            sprite.color = new Color(r, g, b);
        }

    }
}
