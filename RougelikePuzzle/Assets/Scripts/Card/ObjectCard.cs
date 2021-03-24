using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectCard : Card
{
    #region Override
    public override void OnDamage()
    {
        VirtualOnDamage();
    }

    public override void TurnEvent()
    {
        VirtualTurnEvent();
    }
    #endregion

    #region Virtual
    public virtual void VirtualOnDamage()
    {

    }

    public virtual void VirtualInteractable()
    {

    }

    public virtual void VirtualTurnEvent()
    {

    }
    #endregion

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

            switch (moveable)
            {
                case Moveable.Immovable:
                    VirtualInteractable();
                    break;
                case Moveable.Movable:
                    InGameManager.instance.player.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InBack).OnComplete(() => {

                        Vector2Int tempVec = vector;
                        SetVector(InGameManager.instance.player.vector.x, InGameManager.instance.player.vector.y);
                        InGameManager.instance.player.SetVector(tempVec.x, tempVec.y);

                        VirtualInteractable();
                    });
                    break;
            }
        }
        else
        {
            ShowInfoUI();
        }
    }
}
