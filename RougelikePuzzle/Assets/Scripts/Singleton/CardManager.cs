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

    public List<Card> GetSameXCards(Card card)
    {
        List<Card> cards = new List<Card>();

        for(int i = -1; i <= 1; i++)
        {
            Card c = GetCard(card.vector.x, i);
            if (c != card)
                cards.Add(c);
        }

        return cards;
    }

    public List<Card> GetSameYCards(Card card)
    {
        List<Card> cards = new List<Card>();

        for (int i = -1; i <= 1; i++)
        {
            Card c = GetCard(i, card.vector.y);
            if (c != card)
                cards.Add(c);
        }

        return cards;
    }

    public List<Card> GetSameXAndYCards(Card card)
    {
        List<Card> cards = new List<Card>();

        for (int i = -1; i <= 1; i++)
        {
            Card c = GetCard(card.vector.x, i);
            if (c != card)
                cards.Add(c);
        }

        for (int i = -1; i <= 1; i++)
        {
            Card c = GetCard(i, card.vector.y);
            if (c != card)
                cards.Add(c);
        }

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
        int selectedIdx = -1;

        if (card.cardData.dropCardType == Define.CardType.None)
        {
            int len = categoryPercent.Length;
            int sum = 0;

            for (int i = 0; i < len; i++)
            {
                sum += categoryPercent[i];
            }

            int categoryIdx = Random.Range(0, sum);

            for (int i = 0; i < len; i++)
            {
                if (categoryIdx < categoryPercent[i])
                {
                    selectedIdx = i;
                    break;
                }
                else
                {
                    categoryIdx -= categoryPercent[i];
                }
            }
        }
        else
        {
            selectedIdx = (int)card.cardData.dropCardType;
        }
        Card newCard = NewCardType(selectedIdx);
        newCard.SetVector(card.vector.x, card.vector.y);
        newCard.transform.SetParent(cardsParents.transform);
        newCard.transform.position = new Vector2(card.vector.x * PADDING, card.vector.y * PADDING);
        if(InGameManager.instance.isDay)
            newCard.GetComponent<SpriteRenderer>().sprite = InGameManager.instance.tileSprite[0];
        else
            newCard.GetComponent<SpriteRenderer>().sprite = InGameManager.instance.tileSprite[1];
        newCard.gameObject.SetActive(true);
        newCard.SetData();

        card.ReturnCard();
        cardQueue = new Queue<Card>(cardQueue.Where(x => x != card));
        cardQueue.Enqueue(newCard);

        return newCard;
    }

    private Card NewCardType(int idx)
    {
        switch (idx)
        {
            case 0:
                return SelectMonster();
            case 1:
                return ObjectPoolManager.instance.GetWeapon();
            case 2:
                return SelectPotion();
            case 3:
                return ObjectPoolManager.instance.GetGoldCoin();
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

    private Potion SelectPotion()
    {
        Potion returnPotion = null;

        int potionLength = potionPercent.Length;
        int potionidx = -1;
        int sum = 0;

        for(int i = 0; i < potionLength; i++)
        {
            sum += potionPercent[i];
        }

        int randomValue = Random.Range(0, sum);

        for (int i = 0; i < potionLength; i++)
        {
            if(randomValue < potionPercent[i])
            {
                potionidx = i;
                break;
            }

            randomValue -= potionPercent[i];
        }

        switch (potionidx)
        {
            case 0:
                returnPotion = ObjectPoolManager.instance.GetBlackPotion();
                break;
            case 1:
                returnPotion = ObjectPoolManager.instance.GetBluePotion();
                break;
            case 2:
                returnPotion = ObjectPoolManager.instance.GetPinkPotion();
                break;
            case 3:
                returnPotion = ObjectPoolManager.instance.GetPurplePotion();
                break;
            case 4:
                returnPotion = ObjectPoolManager.instance.GetRedPotion();
                break;
            case 5:
                returnPotion = ObjectPoolManager.instance.GetYellowPotion();
                break;
        }

        return returnPotion;
    }

    private Monster SelectMonster()
    {
        Monster returnMonster = null;

        int monsterLength = monsterPercent.Length;
        int monsterIdx = -1;
        int sum = 0;

        for (int i = 0; i < monsterLength; i++)
        {
            sum += monsterPercent[i];
        }

        int randomValue = Random.Range(0, sum);

        for (int i = 0; i < monsterLength; i++)
        {
            if (randomValue < monsterPercent[i])
            {
                monsterIdx = i;
                break;
            }

            randomValue -= monsterPercent[i];
        }

        switch (monsterIdx)
        {
            case 0:
                returnMonster = ObjectPoolManager.instance.GetGhostMonster();
                break;
            case 1:
                returnMonster = ObjectPoolManager.instance.GetSlimeMonster();
                break;
            case 2:
                returnMonster = ObjectPoolManager.instance.GetImpMonster();
                break;
        }

        return returnMonster;
    }
}
