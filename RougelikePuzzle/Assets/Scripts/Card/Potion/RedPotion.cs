using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : Potion
{
    public override void GetPotion()
    {

    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnRedPotion(this);
    }
}
