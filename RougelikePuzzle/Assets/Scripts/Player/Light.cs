using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Player
{
    protected override void OnDamageEvent(int damage)
    {
        if(value >= maxValue / 2)
        {
            TakeDamage(damage / 2);
        }
        else
        {
            TakeDamage(damage);
        }
    }
}
