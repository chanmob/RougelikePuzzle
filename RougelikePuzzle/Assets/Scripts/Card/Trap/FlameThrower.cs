using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlameThrower : Trap
{
    public override void TriggerTrap()
    {
        int x = vector.x;
        int y = vector.y;

        switch (turnCount % 4)
        {
            case 0:
                y++;
                if (y <= 1)
                {
                    Card card = CardManager.instance.GetCard(x, y);
                    card.GetDamage(value, this);
                }
                break;
            case 1:
                x++;
                if (x <= 1)
                {
                    Card card = CardManager.instance.GetCard(x, y);
                    card.GetDamage(value, this);
                }
                break;
            case 2:
                y--;
                if (y >= -1)
                {
                    Card card = CardManager.instance.GetCard(x, y);
                    card.GetDamage(value, this);
                }
                break;
            case 3:
                x--;
                if (x >= -1)
                {
                    Card card = CardManager.instance.GetCard(x, y);
                    card.GetDamage(value, this);
                }
                break;
        }

        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualTurnEvent()
    {
        turnCount++;
        _spriteRender.transform.DORotate(new Vector3(0, 0, (turnCount % 4) * 90), 0.5f);
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnFlameThrower(this);
    }
}
