using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{

   
    SpriteRenderer spriteObj;
    public RawImage maskImage;
    Texture2D spriteTex;
    public Texture2D maskTex;
    [SerializeField]
    GameObject maskSpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startが呼び出された");
        spriteObj = SpriteTagetChanger.CurrentSprite;
        if(GetComponentInChildren<RawImage>())
            spriteTex = GetComponentInChildren<RawImage>().texture as Texture2D;
    }
    public void SpriteChange()
    {
        
        spriteObj.sprite = Sprite.Create(spriteTex, new Rect(0f,0f, spriteTex.width, spriteTex.height), new Vector2(0.5f,0.5f), 100.0f);
                
        if(maskTex){
            spriteObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Sprite.Create(maskTex,new Rect(0f,0f, spriteTex.width, spriteTex.height), new Vector2(0.5f,0.5f), 100.0f);
            Debug.Log("maskTexはNullではない");
        }else{
            spriteObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        }
    }
    public void RemoveSprite(){
        SpriteTagetChanger.CurrentSprite.sprite = null;
        SpriteTagetChanger.CurrentSprite.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }
    void OnDestroy()
    {
        maskTex = null;
    }
}
