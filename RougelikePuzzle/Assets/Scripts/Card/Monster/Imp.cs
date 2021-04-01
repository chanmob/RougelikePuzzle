using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Monster
{
    public override void MonsterTurnEvent()
    {
        if(InGameManager.instance.player.weaponType == Define.WeaponType.None)
        {
            SetValue(0);
        }
        else
        {
            SetValue(maxValue);
        }
    }
}
