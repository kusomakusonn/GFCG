using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform cardParent;
    public CardController card;

    private void Awake()
    {
        card = GetComponent<CardController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(card.model.place == CardModel.Place.Hand && card.model.isPlayerCard == BattleStatus.isPlayerTurn)
        {
            if(card.model.kinds.gun)
            {
                cardParent = transform.parent;
                transform.SetParent(cardParent.root, false);
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(card.model.place == CardModel.Place.Hand && card.model.isPlayerCard == BattleStatus.isPlayerTurn)
        {
            if(card.model.kinds.gun)
            {
                transform.position = eventData.position;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(card.model.isPlayerCard == BattleStatus.isPlayerTurn)
        {
            if(card.model.kinds.gun)
            {
                transform.SetParent(cardParent, false);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
    }
}