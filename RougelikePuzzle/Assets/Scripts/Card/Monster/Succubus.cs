using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succubus : Monster
{
    public override void MonsterTurnEvent()
    {
        List<Card> nearCards = CardManager.instance.Get4WayCards(this);
        int cardLen = nearCards.Count;

        for(int i = 0; i < cardLen; i++)
        {
            if(nearCards[i].value != 0)
            {
                nearCards[i].GetHeal(1);
            }
        }
    }
}
