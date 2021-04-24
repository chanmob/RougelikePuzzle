using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : ObjectCard
{
    public override void VirtualInteractable()
    {
        int tempHp = value;

        if (InGameManager.instance.player.weaponType != Define.WeaponType.None)
        {
            InGameManager.instance.player.weapon.Attack(this);
            InGameManager.instance.player.GetDamage(tempHp, this);

            if (value <= 0)
            {
                Die();
            }
        }

        else
        {
            GetDamage(InGameManager.instance.player.value, this);
            InGameManager.instance.player.GetDamage(tempHp, this);

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
        MonsterTurnEvent();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnGhostMonster(this);
    }

    public virtual void MonsterTurnEvent()
    {

    }

    private void Die()
    {
        CardManager.instance.ChangeNewCard(this);
    }
}
