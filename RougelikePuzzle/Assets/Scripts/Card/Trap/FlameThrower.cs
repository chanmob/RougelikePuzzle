using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    card.GetDamage(value);
                }
                break;
            case 1:
                x++;
                if (x <= 1)
                {
                    Card card = CardManager.instance.GetCard(x, y);
                    card.GetDamage(value);
                }
                break;
            case 2:
                y--;
                if (y >= -1)
                {
                    Card card = CardManager.instance.GetCard(x, y);
                    card.GetDamage(value);
                }
                break;
            case 3:
                x--;
                if (x >= -1)
                {
                    Card card = CardManager.instance.GetCard(x, y);
                    card.GetDamage(value);
                }
                break;
        }
    }
}
