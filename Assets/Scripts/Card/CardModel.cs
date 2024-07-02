using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel
{
    public bool isPlayerCard;
    public Place place;
    public enum Place{
        Deck,
        Hand,
        Field,
        Grave,
    }
    public int cardId;
    public string name;
    public string effect;
    public Sprite icon;

    public Kinds kinds = new();
    public class Kinds
    {
        public bool gun;
        public bool senryaku;
    }

    public GunElements gunElements = new();
    public class GunElements
    {
        public int power;
        public int ammunition;
        public int hituyousuu;
        public int addAmmunition;
        public int addAmmunitionJougenn;
        public int kaisuu;
        public int kaisuuJougenn;
        public bool nibasukoKa;
        public GameObject ura;
    }
    
    public SenryakuElements senryakuElements = new();
    public class SenryakuElements
    {
        public int ikenie;
    }
    
    public CardModel(int cardID, bool IsPlayerCard)
    {
        CardEntity card = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);
        
        isPlayerCard = IsPlayerCard;
        place = Place.Hand;
        cardId = cardID;
        name = card.name;
        effect = card.effect;
        icon = card.icon;
        kinds.gun = card.kinds.gun;
        kinds.senryaku = card.kinds.senryaku;
        if(card.kinds.gun)
        {
            gunElements.power = card.elements.gunElements.power;
            gunElements.hituyousuu = card.elements.gunElements.hituyousuu;
            gunElements.kaisuuJougenn = card.elements.gunElements.kaisuujougenn;
            gunElements.nibasukoKa = card.elements.gunElements.nibasukoka;
            gunElements.ura = card.elements.gunElements.ura;
        }
    }

    public void ChangeTurn()
    {
        gunElements.kaisuu = 0;
    }
}
