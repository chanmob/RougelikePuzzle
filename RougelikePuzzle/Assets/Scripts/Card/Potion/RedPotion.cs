using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : Potion
{
    public override void GetPotion()
    {
        int healHP = InGameManager.instance.player.value + value;
        if (InGameManager.instance.player.maxValue < healHP)
            InGameManager.instance.player.value = InGameManager.instance.player.maxValue;
        else
            InGameManager.instance.player.value = healHP;

        InGameManager.instance.player.PlayerHPTextRefresh();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnRedPotion(this);
    }
}
