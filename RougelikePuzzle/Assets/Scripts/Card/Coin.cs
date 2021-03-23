using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : Card
{
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

            });
        }
        else
        {
            ShowInfoUI();
        }
    }
}
