using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Monster
{
    public override void MonsterTurnEvent()
    {
        AddMaxValue(1, true);
    }
}
