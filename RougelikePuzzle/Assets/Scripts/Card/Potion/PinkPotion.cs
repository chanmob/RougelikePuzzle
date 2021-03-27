using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPotion : Potion
{
    public override void GetPotion()
    {
        int healHP = InGameManager.instance.player.value * 2;
        if (InGameManager.instance.player.maxValue < healHP)
            InGameManager.instance.player.value = InGameManager.instance.player.maxValue;
        else
            InGameManager.instance.player.value = healHP;

        InGameManager.instance.player.PlayerHPTextRefresh();
    }
}
