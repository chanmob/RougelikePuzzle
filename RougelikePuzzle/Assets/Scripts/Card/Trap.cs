using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap : ObjectCard
{
    public override void VirtualInteractable()
    {
        TriggerTrap();
    }

    public override void VirtualOnDamage()
    {
        CardManager.instance.ChangeNewCard(this);
        //TriggerTrap();
    }

    public virtual void TriggerTrap()
    {
        
    }
}
