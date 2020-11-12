using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShirtInToggle : MonoBehaviour
{
    Toggle shirtIn{set;get;}
    [SerializeField]
    SpriteRenderer bottoms;
    [SerializeField]
    SpriteRenderer inner;
 
    // Update is called once per frame

    public ShirtInToggle()
    {
    }


    void Start(){
        shirtIn = GetComponent<Toggle>();
    }
    
    void Update(){
        if(shirtIn.isOn){
            while(inner.sortingOrder >= bottoms.sortingOrder){
                inner.sortingOrder--;
                
            }
        }else {
            while(inner.sortingOrder <= bottoms.sortingOrder){
                inner.sortingOrder++;
                
            }
        }
    }
}
