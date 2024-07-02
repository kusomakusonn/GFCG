using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text nameText, effectText, powerText;
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel)
    {
        nameText.text = cardModel.name;
        iconImage.sprite = cardModel.icon;
        effectText.text = cardModel.effect;
        if(cardModel.kinds.gun)
        {
            powerText.text = cardModel.gunElements.power.ToString();
        }
        if(cardModel.kinds.senryaku)
        {
        }
    }
}