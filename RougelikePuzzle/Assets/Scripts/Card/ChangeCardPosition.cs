using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCardPosition : ObjectCard
{
    public override void VirtualInteractable()
    {
        int n = CardManager.instance.cards.Count;
        int len = n;
        while (n > 1)
        {
            n--;
            int k = new System.Random().Next(n + 1);
            Card value = CardManager.instance.cards[k];
            CardManager.instance.cards[k] = CardManager.instance.cards[n];
            CardManager.instance.cards[n] = value;
        }

        int x = -1;
        int y = -1;

        for (int i = 0; i < len; i++)
        {
            Card card = CardManager.instance.cards[i];

            card.vector.x = x;
            card.vector.y = y;
            card.transform.position = new Vector2(card.vector.x * CardManager.PADDING, card.vector.y * CardManager.PADDING);

            y++;
            if (y > 1)
            {
                x++;
                y = -1;
            }
        }
    }

    public override void VirtualOnDamage()
    {
        base.VirtualOnDamage();
    }

    public override void VirtualTurnEvent()
    {
        base.VirtualTurnEvent();
    }
}
