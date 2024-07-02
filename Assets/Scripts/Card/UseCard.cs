using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseCard : MonoBehaviour
{
    private GameManager gameManager;
    private CardController card;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        card = GetComponent<CardController>();
    }

    public void GameObjectClick()
    {
        if(card.model.isPlayerCard == BattleStatus.isPlayerTurn)
        {
            if(card.model.kinds.gun)
            {
                if(card.model.place == CardModel.Place.Field)
                {
                    Debug.Log("Attack!");
                    gameManager.GunAttack(card.model);
                }
            }
            if(card.model.kinds.senryaku)
            {
            }
        }
    }
}