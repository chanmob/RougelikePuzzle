using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : Card
{
    public void OnMouseDown()
    {
        _clickTime = Time.time;
    }

    public void OnMouseUp()
    {
        if(Time.time - _clickTime < ONUITIME)
        {
            if (!CardManager.instance.CheckDistance(this))
                return;

            int wd = InGameManager.instance.player.weaponDurability;
            int tempHp = value;

            if (wd > 0)
            {
                GetDamage(wd);
                InGameManager.instance.player.DecreaseWeaponDurability(tempHp);

                if (value <= 0)
                {
                    Die();
                }
            }
            else
            {
                GetDamage(InGameManager.instance.player.value);
                InGameManager.instance.player.GetDamage(tempHp);

                if (value <= 0)
                {
                    Die();
                }
            }
        }
        else
        {
            ShowInfoUI();
        }
    }

    private void Die()
    {

    }
}
