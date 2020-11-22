using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpriteTagetChanger : MonoBehaviour
{
    [SerializeField]
    public static SpriteRenderer CurrentSprite;
    public Color spriteColor;
    [SerializeField] Slider slider_R;
    [SerializeField] Slider slider_G;
    [SerializeField] Slider slider_B;

    void Update(){
        SpriteColorChange_R();
        SpriteColorChange_G();
        SpriteColorChange_B();
    }
    public void ColorSet()
    {
        spriteColor = CurrentSprite.color;
    }

    public void ChangeCurrentSprite(SpriteRenderer changeSprite)
    {
        CurrentSprite = changeSprite;
        
        slider_G.value = CurrentSprite.color.g;
        slider_R.value = CurrentSprite.color.r;
        slider_B.value = CurrentSprite.color.b;
        
    }



    public void SpriteColorChange_R()
    {
        try{
            CurrentSprite.color = new Color(slider_R.value, spriteColor.g, spriteColor.b);
            spriteColor = new Color(slider_R.value, spriteColor.g, spriteColor.b);
        }catch(Exception){
            
        }
    }
    public void SpriteColorChange_G()
    {

        CurrentSprite.color = new Color(spriteColor.r, slider_G.value, spriteColor.b);
        spriteColor = new Color(spriteColor.r, slider_G.value, spriteColor.b);
    }
    public void SpriteColorChange_B()
    {

        CurrentSprite.color = new Color(spriteColor.r, spriteColor.g, slider_B.value);
        spriteColor = new Color(spriteColor.r, spriteColor.g, slider_B.value);
    }

}
