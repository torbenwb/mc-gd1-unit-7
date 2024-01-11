using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICursorCapture : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool cursorOverUI = false;

    public void OnPointerEnter(PointerEventData eventData){
        //Debug.Log("Pointer Enter");
        cursorOverUI = true;
    }   

    public void OnPointerExit(PointerEventData eventData){
        //Debug.Log("Pointer Exit");
        cursorOverUI = false;
    }
}
