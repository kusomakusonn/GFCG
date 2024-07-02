using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AmmunitionDropPlace : MonoBehaviour, IDropHandler
{
    [SerializeField] Transform attachField;
    public void OnDrop(PointerEventData eventData)
    {
        CreateAmmunition card = eventData.pointerDrag.GetComponent<CreateAmmunition>();
        if(card != null)
        {
            card.ammunitionCardParent = transform.Find("AttachField").transform;
        }
    }
}
