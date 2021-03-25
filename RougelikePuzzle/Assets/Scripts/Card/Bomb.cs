using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ObjectCard
{
    public override void VirtualInteractable()
    {
        BombExplosion();
    }

    public override void VirtualOnDamage()
    {
        BombExplosion();
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
        Debug.Log("BombExplosion");

        List<Card> cards = CardManager.instance.Get4WayCards(this);

        int len = cards.Count;

        for(int i = 0; i < len; i++)
        {
            cards[i].GetDamage(value);
        }
    }
}
