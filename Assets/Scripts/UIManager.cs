using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text turnText, playerHPText, enemyHPText, playerAmmunitionText, enemyAmmunitionText;
    public void Show()
    {
        playerHPText.text = BattleStatus.playerHP.ToString();
        enemyHPText.text = BattleStatus.enemyHP.ToString();
        playerAmmunitionText.text = BattleStatus.playerAmmunition.ToString();
        enemyAmmunitionText.text = BattleStatus.enemyAmmunition.ToString();
    }
}
