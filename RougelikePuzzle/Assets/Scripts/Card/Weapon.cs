using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : ObjectCard
{
    public Define.WeaponType weaponType = Define.WeaponType.None;

    public override void VirtualInteractable()
    {
        InGameManager.instance.player.PlayerGetWeapon(weaponType, value);
    }

    public override void VirtualOnDamage()
    {
        base.VirtualOnDamage();
    }

    public override void VirtualTurnEvent()
    {
        base.VirtualTurnEvent();
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnWeapon(this);
    }
}
