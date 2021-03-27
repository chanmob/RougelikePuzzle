using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePotion : Potion
{
    public override void GetPotion()
    {
        InGameManager.instance.player.value = 1;
        InGameManager.instance.player.PlayerHPTextRefresh();
    }
}
