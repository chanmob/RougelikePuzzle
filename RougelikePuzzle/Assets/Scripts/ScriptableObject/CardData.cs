using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Object Asset/CardData", order = 1)]
public class CardData : ScriptableObject
{
    public string cardName;
    public string cardInfo;

    public Sprite cardSprite;

    public bool isRandom;

    public int randomMinValue;
    public int randomMaxValue;
    public int fixValue;

    public Define.CardType cardType = Define.CardType.None;
    public Define.CardType dropCardType = Define.CardType.None;
}
