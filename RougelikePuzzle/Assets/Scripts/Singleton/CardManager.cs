using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardManager : Singleton<CardManager>
{
    public const float PADDING = 1.5f;

    public CardData tempData;

    public GameObject cardsParents;

    public List<Card> cards;

    private int _cardsLen;

    private void Start()
    {
        cards = cardsParents.GetComponentsInChildren<Card>().ToList();
        _cardsLen = cards.Count;

        ResetCard();
    }

    public bool CheckDistance(Card card)
    {
        return Mathf.Abs((InGameManager.instance.player.vector.x + card.vector.x) - (InGameManager.instance.player.vector.y - card.vector.y)) == 1;
    }

    public List<Card> Get4WayCards(Card card)
    {
        List<Card> cards = new List<Card>();

        int right = card.vector.x + 1;
        int left = card.vector.x - 1;
        int top = card.vector.y + 1;
        int bottom = card.vector.y - 1;

        if (right <= 1)
            cards.Add(GetCard(right, card.vector.y));

        if (left >= -1)
            cards.Add(GetCard(left, card.vector.y));

        if (top <= 1)
            cards.Add(GetCard(card.vector.x, top));

        if (bottom >= -1)
            cards.Add(GetCard(card.vector.x, bottom));

        return cards;
    }

    public List<Card> GetRightLeftCards(Card card)
    {
        List<Card> cards = new List<Card>();

        int right = card.vector.x + 1;
        int left = card.vector.x - 1;

        if (right <= 1)
            cards.Add(GetCard(right, card.vector.y));

        if (left >= -1)
            cards.Add(GetCard(left, card.vector.y));

        return cards;
    }

    public List<Card> GetTopBottomCards(Card card)
    {
        List<Card> cards = new List<Card>();

        int top = card.vector.y + 1;
        int bottom = card.vector.y - 1;

        if (top <= 1)
            cards.Add(GetCard(card.vector.x, top));

        if (bottom >= -1)
            cards.Add(GetCard(card.vector.x, bottom));

        return cards;
    }

    public Card GetCard(int x, int y)
    {
        for (int i = 0; i < _cardsLen; i++)
        {
            if (cards[i].vector.x == x && cards[i].vector.y == y)
                return cards[i];
        }

        return null;
    }

    public void ResetCard()
    {
        int x = -1;
        int y = -2;

        for (int i = 0; i < _cardsLen; i++)
        {
            Card card = cards[i];

            y++;
            if (y > 1)
            {
                x++;
                y = -1;
            }

            if (card is Player)
                continue;

            card.SetData(tempData);
            card.vector.x = x;
            card.vector.y = y;
            card.transform.position = new Vector2(card.vector.x * PADDING, card.vector.y * PADDING);
        }
    }

    public Card ChangeNewCard(Card card)
    {
        //카드 목록 확률에 따라 카드 목록 선택

        //카드 목록에 따라 세부적인 것 결정

        //그 카드 리턴

        return null;
    }
}
