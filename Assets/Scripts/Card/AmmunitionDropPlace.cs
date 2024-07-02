using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AmmunitionDropPlace : MonoBehaviour, IDropHandler
{
    [SerializeField] Transform attachField;
    private CardController cardI;

    private void Awake()
    {
        cardI = GetComponent<CardController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(cardI.model.place == CardModel.Place.Field && cardI.model.isPlayerCard == BattleStatus.isPlayerTurn)
        {
            CreateAmmunition ammunition = eventData.pointerDrag.GetComponent<CreateAmmunition>();
            if(ammunition != null)
            {
                ammunition.ammunitionCardParent = transform.Find("AttachField").transform;
            }
        }
    }
}
