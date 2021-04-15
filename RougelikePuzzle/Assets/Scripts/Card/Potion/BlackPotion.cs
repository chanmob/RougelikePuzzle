using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPotion : Potion
{
    public override void GetPotion()
    {
        InGameManager.instance.player.maxValue -= value;

        if (InGameManager.instance.player.maxValue < InGameManager.instance.player.value)
            InGameManager.instance.player.value = InGameManager.instance.player.maxValue;

        InGameManager.instance.player.PlayerHPTextRefresh();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnBlackPotion(this);
    }
}
