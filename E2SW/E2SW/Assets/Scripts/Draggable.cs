using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    

   private Vector2 startMousePos, startWNDPos;

   public void OnBeginDrag(PointerEventData eventData)
   {
       startMousePos = eventData.position;
       startWNDPos = transform.position;
   }

   public void OnDrag(PointerEventData eventData)
   {
       transform.position = (eventData.position - startMousePos) + startWNDPos;
   }



}
