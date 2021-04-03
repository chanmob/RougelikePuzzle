using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InGameManager : Singleton<InGameManager>
{
    public Color dayColor;
    public Color nightColor;

    public Player player { get; private set; }

    private int _getCoin = 0;
    private int _turn = 1;

    public bool isDay = true;

    private float changeColorTime = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void GetCoin(int coin)
    {
        _getCoin += coin;
    }

    public void TurnEnd()
    {
        _turn++;

        if (_turn % 4 == 0)
        {
            isDay = !isDay;
            ChangeCameraBackgroundColor();
        }
    }

    private void ChangeCameraBackgroundColor()
    {
        if (isDay)
        {
            Camera.main.DOColor(dayColor, changeColorTime);
        }
        else
        {
            Camera.main.DOColor(nightColor, changeColorTime);
        }
    }
}
