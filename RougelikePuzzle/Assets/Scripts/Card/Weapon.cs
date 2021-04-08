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
        InGameManager.instance.player.weapon = this;
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


    public virtual void WeaponEventBeforeGetDamage(Card card)
    {

    }

    public virtual void WeaponEventAfterGetDamage(Card card)
    {

    }

    public virtual void WeaponEventBeforeAttack(Card card)
    {

    }

    public virtual void WeaponEventAfterAttack(Card card)
    {

    }

    public virtual void Attack(Card card)
    {
        WeaponEventBeforeAttack(card);
        card.GetDamage(InGameManager.instance.player.weaponDurability, this);
        WeaponEventAfterAttack(card);
    }
}
