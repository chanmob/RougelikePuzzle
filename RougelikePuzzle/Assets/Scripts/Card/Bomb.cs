using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ObjectCard
{
    public override void VirtualInteractable()
    {
        BombExplosion();
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualOnDamage()
    {
        //BombExplosion();
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualTurnEvent()
    {
        base.VirtualTurnEvent();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnBomb(this);
    }

    public void BombExplosion()
    {
        List<Card> cards = CardManager.instance.Get4WayCards(this);

        int len = cards.Count;

        for(int i = 0; i < len; i++)
        {
            cards[i].GetDamage(value, this);
        }
    }
}
