using System.Collections;
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

            card.SetData();
            card.vector.x = x;
            card.vector.y = y;
            card.transform.position = new Vector2(card.vector.x * PADDING, card.vector.y * PADDING);
        }
    }

    public Card ChangeNewCard(Card card)
    {
        Card returnCard = null;
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
            }
            else
            {
                categoryIdx -= categoryPercent[i];
            }
        }

        switch (selectedIdx)
        {
            case 0:
                returnCard = DataManager.instance.monster;
                break;
            case 1:
                returnCard = DataManager.instance.weapon;
                break;
            case 2:
                returnCard = DataManager.instance.potion;
                break;
            case 3:
                returnCard = DataManager.instance.coin;
                break;
            case 4:
                returnCard = DataManager.instance.changeCardPosition;
                break;
            case 5:
                returnCard = DataManager.instance.cardReset;
                break;
            case 6:
                returnCard = DataManager.instance.flameThrower;
                break;
            case 7:
                returnCard = DataManager.instance.thorn;
                break;
            case 8:
                returnCard = DataManager.instance.bomb;
                break;
        }

        card.gameObject.SetActive(false);
        Card c = Instantiate(returnCard);
        c.transform.position = new Vector2(card.vector.x * PADDING, card.vector.y * PADDING);
        c.SetData();
        return c;
    }
}
