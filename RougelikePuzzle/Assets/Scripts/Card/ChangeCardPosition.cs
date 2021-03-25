using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCardPosition : ObjectCard
{
    public override void VirtualInteractable()
    {
        Card[] cards = CardManager.instance.cardQueue.ToArray();
        int n = cards.Length;
        int len = n;
        while (n > 1)
        {
            n--;
            int k = new System.Random().Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }

        int x = -1;
        int y = -1;

        CardManager.instance.cardQueue.Clear();

        for (int i = 0; i < len; i++)
        {
            Card card = cards[i];

            card.SetVector(x, y);
            card.transform.position = new Vector2(x * CardManager.PADDING, y * CardManager.PADDING);
            card.ScaleAnimation();
            CardManager.instance.cardQueue.Enqueue(card);

            y++;
            if (y > 1)
            {
                x++;
                y = -1;
            }

        }

        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualOnDamage()
    {
        base.VirtualOnDamage();
    }

    public override void VirtualTurnEvent()
    {
        base.VirtualTurnEvent();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnChangeCardPosition(this);
    }
}
