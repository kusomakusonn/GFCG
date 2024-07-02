using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardController cardPrefab;
    public Transform playerHand, enemyHand, playerField, enemyField;
    public Transform playerAmmunition, enemyAmmunition, playerHP, enemyHP;
    List<int> deck = new();
    public UIManager uIManager;
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        BattleStatus.Reset();
        uIManager.Show();
        SetStartHand();
        TurnCalc();
    }
    void SetStartHand()
    {
        for (int i = 0; i <= 2; i++)
        {
            DrawCard(playerHand, true);
            DrawCard(enemyHand, false);
        }
    }
    void TurnCalc()
    {
        if (BattleStatus.isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }
    public void ChangeTurn()
    {
        BattleStatus.isPlayerTurn = !BattleStatus.isPlayerTurn;
        TurnCalc();
    }
    void PlayerTurn()
    {
        Debug.Log("Playerのターン");
        CardController[] fieldCardList = playerField.GetComponentsInChildren<CardController>();
        foreach(CardController card in fieldCardList)
        {
            card.model.ChangeTurn();
        }
        BattleStatus.playerAmmunition += 1;
        AddAmmunition(playerAmmunition, true);
        uIManager.Show();
        DrawCard(playerHand, true);
    }
    void EnemyTurn()
    {
        Debug.Log("Enemyのターン");
        CardController[] fieldCardList = enemyField.GetComponentsInChildren<CardController>();
        foreach(CardController card in fieldCardList)
        {
            card.model.ChangeTurn();
        }
        BattleStatus.enemyAmmunition += 1;
        AddAmmunition(enemyAmmunition, false);
        uIManager.Show();
        DrawCard(enemyHand, false);
    }
    void CreateCard(int cardID, Transform place, bool IsPlayerCard)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID, IsPlayerCard);
    }
    void DrawCard(Transform hand, bool IsPlayerCard)
    {
        /*if(deck.Count == 0)
        {
            return;
        }*/
        CardController[] handCardList = hand.GetComponentsInChildren<CardController>();
        if(handCardList.Length < 8)
        {
            //int cardID = deck[0];
            //deck.RemoveAt(0);
            CreateCard(Random.Range(1,4), hand, IsPlayerCard);
        }
    }
    void AddAmmunition(Transform place, bool IsPlayerAmmunition)
    {
        //Instantiate(ammunition, place);
    }
    public void GunAttack(CardModel model)
    {
        if(CanAttack(model))
        {
            if(model.gunElements.kaisuuJougenn != -1)
            {
                model.gunElements.kaisuu += 1;
            }
            if(model.isPlayerCard)
            {
                BattleStatus.playerAmmunition -= model.gunElements.hituyousuu;
                BattleStatus.enemyHP -= model.gunElements.power;
            }else
            {
                BattleStatus.enemyAmmunition -= model.gunElements.hituyousuu;
                BattleStatus.playerHP -= model.gunElements.power;
            }
            uIManager.Show();
        }
        bool CanAttack(CardModel model)
        {
            if(model.isPlayerCard)
            {
                if(BattleStatus.playerAmmunition >= model.gunElements.hituyousuu && model.gunElements.kaisuu < model.gunElements.kaisuuJougenn)
                {
                    return true;
                }else
                {
                    return false;
                }
            }else
            {
                if(BattleStatus.enemyAmmunition >= model.gunElements.hituyousuu && model.gunElements.kaisuu < model.gunElements.kaisuuJougenn)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
        }
    }
}