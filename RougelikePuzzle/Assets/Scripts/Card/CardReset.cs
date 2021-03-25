﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardReset : ObjectCard
{
    public override void VirtualInteractable()
    {
        //CardManager.instance.ChangeNewCard(this);
        CardManager.instance.ResetCard();
        ObjectPoolManager.instance.ReturnCardReset(this);
    }

    public override void VirtualOnDamage()
    {
    }

    public override void VirtualTurnEvent()
    {

    }
}
