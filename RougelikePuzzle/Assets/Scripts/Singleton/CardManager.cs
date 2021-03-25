﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardManager : Singleton<CardManager>
{
    public const float PADDING = 1.5f;

    [Header("CategoryPercent")]
    public int[] categoryPercent;

    [Header("Percent")]
    public int[] monsterPercent;

    [Header("CategoryPercent")]
    public int[] weaponPercent;

    [Header("CategoryPercent")]
    public int[] potionPercent;

    [Header("CoinPercent")]
    public int[] coinPercent;

    [Header("RandomEventPercent")]
    public int[] randomeventPercent;

    [Header("TrapPercent")]
    public int[] trapPercent;

    [Space(50f)]
    public GameObject cardsParents;

    public Queue<Card> cardQueue = new Queue<Card>();

    [SerializeField]
    private int _cardsLen;

    private void Start()
    {
        var cards = cardsParents.GetComponentsInChildren<Card>();
        _cardsLen = cards.Length;

        for(int i = 0; i < _cardsLen; i++)
        {
            cardQueue.Enqueue(cards[i]);
        }

        SetStartCard();
    }

    public List<Card> s;

    private void Update()
    {
        s = cardQueue.ToList();
    }

    public bool CheckDistance(Card card)
    {
        return Mathf.Abs(Mathf.Abs((InGameManager.instance.player.vector.x - card.vector.x)) + Mathf.Abs((InGameManager.instance.player.vector.y - card.vector.y))) == 1;
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
        foreach(Card card in cardQueue)
        {
            if(card.vector.x == x && card.vector.y == y)
            {
                return card;
            }
        }

        return null;
    }

    public void ResetCard()
    {
        for (int i = 0; i < _cardsLen; i++)
        {
            Card c = cardQueue.Peek();

            if (c is Player)
            {
                cardQueue.Dequeue();
                cardQueue.Enqueue(c);
                continue;
            }

            ChangeNewCard(c);
        }
    }

    public void SetStartCard()
    {
        int x = -1;
        int y = -2;

        for (int i = 0; i < _cardsLen; i++)
        {
            Card c = cardQueue.Peek();

            y++;
            if (y > 1)
            {
                x++;
                y = -1;
            }

            if (c is Player)
            {
                cardQueue.Dequeue();
                cardQueue.Enqueue(c);
                continue;
            }

            c.SetVector(x, y);
            ChangeNewCard(c);
        }
    }

    public void TurnEventCard()
    {
        foreach(Card card in cardQueue)
        {
            card.TurnEvent();
        }
    }

    public Card ChangeNewCard(Card card)
    {
        int len = categoryPercent.Length;
        int sum = 0;

        for(int i = 0; i < len; i++)
        {
            sum += categoryPercent[i];
        }
         
        int categoryIdx = Random.Range(0, sum);
        int selectedIdx = -1;

        for(int i = 0; i < len; i++)
        {
            if(categoryIdx < categoryPercent[i])
            {
                selectedIdx = i;
                break;
            }
            else
            {
                categoryIdx -= categoryPercent[i];
            }
        }

        Card newCard = NewCardType(selectedIdx);
        newCard.SetVector(card.vector.x, card.vector.y);
        newCard.transform.SetParent(cardsParents.transform);
        newCard.transform.position = new Vector2(card.vector.x * PADDING, card.vector.y * PADDING);
        newCard.gameObject.SetActive(true);
        newCard.SetData();

        card.ReturnCard();
        cardQueue = new Queue<Card>(cardQueue.Where(x => x != card));
        cardQueue.Enqueue(newCard);

        return newCard;
    }

    private Card NewCardType(int idx)
    {
        return ObjectPoolManager.instance.GetChangeCardPosition();

        switch (idx)
        {
            case 0:
                return ObjectPoolManager.instance.GetMonster();
            case 1:
                return ObjectPoolManager.instance.GetWeapon();
            case 2:
                return ObjectPoolManager.instance.GetRedPotion();
            case 3:
                return ObjectPoolManager.instance.GetCoin();
            case 4:
                return ObjectPoolManager.instance.GetChangeCardPosition();
            case 5:
                return ObjectPoolManager.instance.GetCardReset();
            case 6:
                return ObjectPoolManager.instance.GetFlameThrower();
            case 7:
                return ObjectPoolManager.instance.GetThorn();
            case 8:
                return ObjectPoolManager.instance.GetBomb();
        }

        return null;
    }
}
