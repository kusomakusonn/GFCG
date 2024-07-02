using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card")]

[System.Serializable]
public class CardEntity : ScriptableObject
{
    public int cardId;
    public new string name;
    public string effect;
    public Sprite icon;
    public Kinds kinds;
    public Elements elements;
}

[System.Serializable]
public class Kinds
{
    public bool gun;
    public bool senryaku;
}

[System.Serializable]
public class Elements
{
    public GunElements gunElements;
    public SenryakuElements senryakuElements;
}

[System.Serializable]
public class GunElements
{
    public int power;
    public int hituyousuu;
    public int kaisuujougenn;
    public bool nibasukoka;
    public GameObject ura;
}

[System.Serializable]
public class SenryakuElements
{
    public int ikenie;
}