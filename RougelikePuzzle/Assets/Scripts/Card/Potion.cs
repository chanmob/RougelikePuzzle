using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Potion : ObjectCard
{
    public override void VirtualOnDamage()
    {
        base.VirtualOnDamage();
    }

    public override void VirtualInteractable()
    {
        GetPotion();
    }

    public override void VirtualTurnEvent()
    {
        base.VirtualTurnEvent();
    }

    public virtual void GetPotion()
    {

    }
}
