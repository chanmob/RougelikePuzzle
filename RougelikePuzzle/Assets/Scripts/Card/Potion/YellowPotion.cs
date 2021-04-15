using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPotion : Potion
{
    public override void GetPotion()
    {
        InGameManager.instance.player.value /= 2;
        InGameManager.instance.player.PlayerHPTextRefresh();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnYellowPotion(this);
    }
}
