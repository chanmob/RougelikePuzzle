using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Player
{
    protected override void OnDamageEvent(int damage, Card card)
    {
        if(value >= maxValue / 2)
        {
            TakeDamage(damage / 2, card);
        }
        else
        {
            TakeDamage(damage, card);
        }
    }
}
