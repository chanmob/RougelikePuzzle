using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : ObjectCard
{
    public override void VirtualInteractable()
    {
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualOnDamage()
    {

    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnCoin(this);
    }
}
