using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : ObjectCard
{
    public override void VirtualInteractable()
    {
        int wd = InGameManager.instance.player.weaponDurability;
        int tempHp = value;

        if (wd > 0)
        {
            GetDamage(wd);
            InGameManager.instance.player.PlayerGetDamage(tempHp);

            if (value <= 0)
            {
                Die();
            }
        }
        else
        {
            GetDamage(InGameManager.instance.player.value);
            InGameManager.instance.player.PlayerGetDamage(tempHp);

            if (value <= 0)
            {
                Die();
            }
        }
    }

    public override void VirtualOnDamage()
    {
    }

    public override void VirtualTurnEvent()
    {
    }

    private void Die()
    {

    }
}
