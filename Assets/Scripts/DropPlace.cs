using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public bool isPlayerField;

    public void OnDrop(PointerEventData eventData)
    {
        CardController[] suu = GetComponentsInChildren<CardController>();
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if(card != null)
        {
            CardController cardController = card.GetComponent<CardController>();
            if(suu.Length < 3)
            {
                card.cardParent = transform;
                cardController.model.place = CardModel.Place.Field;
            }
        }
    }
}