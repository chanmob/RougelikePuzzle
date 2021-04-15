using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotion : Potion
{
    public override void GetPotion()
    {
        InGameManager.instance.player.maxValue += value;

        InGameManager.instance.player.PlayerHPTextRefresh();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnBluePotion(this);
    }
}
