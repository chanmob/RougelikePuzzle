using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : ObjectCard
{
    public override void VirtualInteractable()
    {
        InGameManager.instance.GetCoin(value);
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualOnDamage()
    {
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnGoldCoin(this);
    }
}
