using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private CardView view;
    public CardModel model;

    private void Awake()
    {
        view = GetComponent<CardView>();
    }

    public void Init(int cardID, bool IsPlayerCard)
    {
        model = new CardModel(cardID,IsPlayerCard);
        view.Show(model);
    }
}