using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assasin : Player
{
    protected override void GetWeaponEvent()
    {
        if (value <= maxValue / 2)
        {
            weaponDurability *= 2;
        }
        else
        {
            weaponDurability *= 2;
        }
    }
}
