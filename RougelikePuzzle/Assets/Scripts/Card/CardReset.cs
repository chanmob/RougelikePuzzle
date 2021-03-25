using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardReset : ObjectCard
{
    public override void VirtualInteractable()
    {
        CardManager.instance.ResetCard();
    }

    public override void VirtualOnDamage()
    {
    }

    public override void VirtualTurnEvent()
    {

    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnCardReset(this);
    }
}
