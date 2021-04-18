using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent : ObjectCard
{
    public string eventTitle;
    public string[] button;

    public override void VirtualInteractable()
    {
        base.VirtualInteractable();

        InGameUIManager.instance.ui_RandomEvent.SetRandomEvent(this);
        InGameUIManager.instance.ui_RandomEvent.gameObject.SetActive(true);
    }

    public override void VirtualOnDamage()
    {
        base.VirtualOnDamage();
    }

    public override void VirtualTurnEvent()
    {
        base.VirtualTurnEvent();
    }

    public virtual void FirstAction()
    {

    }

    public virtual void SecondAction()
    {

    }

    public virtual void ThirdAction()
    {

    }

    public virtual void FourthAction()
    {

    }
}