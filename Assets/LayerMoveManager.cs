using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerMoveManager : MonoBehaviour
{

    [SerializeField]
    List<SpriteRenderer> layers;
    [SerializeField]
    SpriteRenderer accesory;
    [SerializeField]
    SpriteRenderer accesorymask;
    [SerializeField]
    Text text;
    const int MOST_BEHIND = 0; 
    int layerFlg = 0;

    void Start(){
        accesory.sortingOrder = layers[0].sortingOrder + 2;
        accesorymask.sortingOrder = layers[0].sortingOrder + 3;

    }

    public void SelectAccesoryLayer(SpriteRenderer layer){
        accesory = layer;
        if(layer.transform.GetChild(0)){
            accesorymask = layer.transform.GetChild(0).GetComponent<SpriteRenderer>();
            Debug.Log("mask取得");
        }
    }

    public void UpLayer() {
        if(layerFlg+1 <= layers.Count){
            layerFlg += 1;
            accesory.sortingOrder = layers[layerFlg].sortingOrder + 2;
            accesorymask.sortingOrder = layers[layerFlg].sortingOrder + 3;
            text.text = layers[layerFlg].name;
        }else{
            
        }
    }
    
    public void DownLayer(){
        if(layerFlg >= 0){
            layerFlg -= 1;
            accesory.sortingOrder = layers[layerFlg].sortingOrder + 2;
            accesorymask.sortingOrder = layers[layerFlg].sortingOrder + 3;
            text.text = layers[layerFlg].name;
        }else{
            accesory.sortingOrder = MOST_BEHIND;
            accesorymask.sortingOrder = MOST_BEHIND + 2;
            text.text = "最背面";
        }
    }

}
