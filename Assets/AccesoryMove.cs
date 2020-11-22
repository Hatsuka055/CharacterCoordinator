using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AccesoryMove : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    
    Vector2 beginPos;
    bool isSpoted;
    public static Transform selectedAccesory;
    
    public void ResetAccesoryPosition(){
        selectedAccesory.localPosition = Vector2.zero;
    }
    public void SelectAccesory(Transform contextTrans){
        selectedAccesory = contextTrans;
    }
    public void OnBeginDrag(PointerEventData data){
        beginPos = this.transform.position; 
    }

    public void OnDrag(PointerEventData data){
        Vector2 vec = selectedAccesory.position; 
        vec.x += data.delta.x * 0.075f;
        vec.y += data.delta.y * 0.075f;
        selectedAccesory.position = vec;
 
        Debug.Log("OnDrag");
    }
    
    public void OnEndDrag(PointerEventData data){

    }

}
