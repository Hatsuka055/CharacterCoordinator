using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReservedColor : MonoBehaviour
{
    
    [SerializeField]
    Image reservedImage;
    static Color reservedColor;
    [SerializeField] Slider slider_R;
    [SerializeField] Slider slider_G;
    [SerializeField] Slider slider_B;

    private void Start() {
        reservedImage = GetComponent<Image>();
        reservedColor = reservedImage.color;
    }

    public void GetColor(){
        float r = SpriteTagetChanger.CurrentSprite.color.r;
        float g = SpriteTagetChanger.CurrentSprite.color.g;
        float b = SpriteTagetChanger.CurrentSprite.color.b;
        reservedImage.color = new Color(r,g,b);
        reservedColor = new Color(r,g,b);
    }

    public void SetColor(){
        slider_R.value = reservedColor.r;
        slider_G.value = reservedColor.g;
        slider_B.value = reservedColor.b;
    }


}
