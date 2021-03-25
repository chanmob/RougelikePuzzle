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
        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualOnDamage()
    {
        CardManager.instance.ChangeNewCard(this);
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
