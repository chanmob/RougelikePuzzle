using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : Card
{
    public Define.WeaponType weaponType = Define.WeaponType.None;

    public void OnMouseDown()
    {
        _clickTime = Time.time;
    }

    public void OnMouseUp()
    {
        if (Time.time - _clickTime < ONUITIME)
        {
            if (!CardManager.instance.CheckDistance(this))
                return;

            InGameManager.instance.player.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InBack).OnComplete(() => {
                InGameManager.instance.player.weaponType = weaponType;
                InGameManager.instance.player.weaponDurability = value;
            });
        }
        else
        {
            ShowInfoUI();
        }
    }
}
