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

    SpriteRenderer inner;
    SpriteRenderer bottoms;
    SpriteRenderer onepiece;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startが呼び出された");
        spriteObj = SpriteTagetChanger.CurrentSprite;
        if(GetComponentInChildren<RawImage>())
            spriteTex = GetComponentInChildren<RawImage>().texture as Texture2D;
        inner = GameObject.Find("inner").GetComponent<SpriteRenderer>();
        bottoms = GameObject.Find("bottoms").GetComponent<SpriteRenderer>();
        onepiece = GameObject.Find("onepiece").GetComponent<SpriteRenderer>();

    }

    //ボタンオブジェクトが保持する着せ替えパーツを使用してスプライトを切り替える
    public void SpriteChange()
    {
        
        if(BottonSpawner.partsName == "onepiece")
        {
            inner.sprite = null;
            bottoms.sprite = null;
        }else if(BottonSpawner.partsName == "bottoms" || BottonSpawner.partsName == "inner")
        {
            onepiece.sprite = null;
            if(!inner.sprite)
                inner.sprite = Resources.Load<Sprite>("Tシャツ");
            if(!bottoms.sprite)
                bottoms.sprite = Resources.Load<Sprite>("ショートパンツ");
            
        }
        spriteObj.sprite = Sprite.Create(spriteTex, new Rect(0f,0f, spriteTex.width, spriteTex.height), new Vector2(0.5f,0.5f), 100.0f);
        //マスクパーツを保持している場合はマスクも切替
        if(maskTex){
            spriteObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Sprite.Create(maskTex,new Rect(0f,0f, spriteTex.width, spriteTex.height), new Vector2(0.5f,0.5f), 100.0f);
            Debug.Log("maskTexはNullではない");
        }else{
            spriteObj.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        }
        Debug.Log("partsName = " + BottonSpawner.partsName);
        //ワンピパーツを着せたらボトムスとインナーを非表示にする
    }

    //パーツ切替時にスプライトをリフレッシュ
    public void RemoveSprite(){
        SpriteTagetChanger.CurrentSprite.sprite = null;
        SpriteTagetChanger.CurrentSprite.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
  
    }
    void OnDestroy()
    {
        maskTex = null;
    }
}
