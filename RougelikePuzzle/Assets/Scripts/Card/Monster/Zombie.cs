using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Monster
{
    public override void MonsterTurnEvent()
    {
        if(value > 1)
        {
            GetDamage(1, this);
        }
    }
}
