using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : Trap
{
    public override void TriggerTrap()
    {
        if(turnCount % 2 == 0)
            InGameManager.instance.player.GetDamage(value, this);

        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnThorn(this);
    }
}
