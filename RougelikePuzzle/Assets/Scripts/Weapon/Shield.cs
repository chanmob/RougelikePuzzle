using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon
{
    public override void Attack(Card card)
    {
        card.GetDamage(card.maxValue, this);
        InGameManager.instance.player.weaponDurability = 0;
        InGameManager.instance.player.weaponType = Define.WeaponType.None;
        InGameManager.instance.player.weapon = null;
    }
}
