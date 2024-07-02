using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleStatus
{
    public static int playerHP, enemyHP, playerAmmunition, enemyAmmunition;
    public static bool isPlayerTurn;

    public static void Reset()
    {
        isPlayerTurn = true;
        playerHP = 10;
        enemyHP = 10;
        playerAmmunition = 0;
        enemyAmmunition = 0;
    }

    public static void AddAmmunition(bool isPlayer, int add)
    {
        if(isPlayer)
        {
            playerAmmunition += add;
        }else
        {
            enemyAmmunition += add;
        }
    }
}
