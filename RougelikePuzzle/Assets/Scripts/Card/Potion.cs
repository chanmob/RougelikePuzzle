using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Potion : ObjectCard
{
    public override void VirtualOnDamage()
    {
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualInteractable()
    {
        GetPotion();
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualTurnEvent()
    {
        base.VirtualTurnEvent();
    }

    public virtual void GetPotion()
    {

    }
}
