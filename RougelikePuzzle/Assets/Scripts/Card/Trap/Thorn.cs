using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : Trap
{
    public Sprite[] thronSprites;

    public override void TriggerTrap()
    {
        if(turnCount % 2 == 0)
            InGameManager.instance.player.GetDamage(value, this);

        CardManager.instance.ChangeNewCard(this);
    }

    public override void VirtualReturnCard()
    {
        ObjectPoolManager.instance.ReturnThorn(this);
    }

    public override void VirtualTurnEvent()
    {
        turnCount++;

        if (turnCount % 2 == 0)
            _spriteRender.sprite = thronSprites[1];
        else
            _spriteRender.sprite = thronSprites[0];
    }

    public override void VirtualOnEnable()
    {
        turnCount = Random.Range(0, 2);

        if (turnCount % 2 == 0)
            _spriteRender.sprite = thronSprites[1];
        else
            _spriteRender.sprite = thronSprites[0];
    }
}
