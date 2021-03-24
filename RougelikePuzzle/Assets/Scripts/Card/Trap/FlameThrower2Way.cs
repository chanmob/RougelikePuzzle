using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower2Way : Trap
{
    public override void TriggerTrap()
    {
        List<Card> cards = new List<Card>();
        int len = 0;

        switch (turnCount % 2)
        {
            case 0:
                cards = CardManager.instance.GetTopBottomCards(this);
                len = cards.Count;

                for(int i = 0; i < len; i++)
                {
                    cards[i].GetDamage(value);
                }
                break;
            case 1:
               cards = CardManager.instance.GetRightLeftCards(this);
                len = cards.Count;

                for (int i = 0; i < len; i++)
                {
                    cards[i].GetDamage(value);
                }
                break;
        }
    }
}
