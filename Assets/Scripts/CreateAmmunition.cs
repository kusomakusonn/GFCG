using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAmmunition : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject ammunitionCardPrefab;
    private GameObject ammunitionCard;
    public Transform ammunitionCardParent;
    public UIManager uIManager;
    public bool isPlayerAmmunition;
    private bool drag;

    private void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(isPlayerAmmunition == BattleStatus.isPlayerTurn)
        {
            if(isPlayerAmmunition)
            {
                if(BattleStatus.playerAmmunition >= 1)
                {
                    drag = true;
                    BattleStatus.AddAmmunition(isPlayerAmmunition, -1);
                    uIManager.Show();
                    ammunitionCardParent = null;
                    ammunitionCard = Instantiate(ammunitionCardPrefab, transform);
                    ammunitionCard.GetComponent<CanvasGroup>().blocksRaycasts = false;
                }else
                {
                    drag = false;
                }
            }else
            {
                if(BattleStatus.enemyAmmunition >= 1)
                {
                    drag = true;
                    BattleStatus.AddAmmunition(isPlayerAmmunition, -1);
                    uIManager.Show();
                    ammunitionCardParent = null;
                    ammunitionCard = Instantiate(ammunitionCardPrefab, transform);
                    ammunitionCard.GetComponent<CanvasGroup>().blocksRaycasts = false;
                }else
                {
                    drag = false;
                }
            }
        }else
        {
            drag = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(drag)
        {
            ammunitionCard.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(drag)
        {
            if(ammunitionCardParent == null)
            {
                BattleStatus.AddAmmunition(isPlayerAmmunition, 1);
                uIManager.Show();
                Destroy(ammunitionCard);
            }else
            {
                ammunitionCard.transform.SetParent(ammunitionCardParent, false);
                ammunitionCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
    }
}