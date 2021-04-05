using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InGameManager : Singleton<InGameManager>
{
    public Color dayColor;
    public Color nightColor;

    [SerializeField]
    public Sprite[] tileSprite;

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

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        TurnEnd();
    //    }
    //}

    public void TurnEnd()
    {
        _turn++;
        InGameUIManager.instance.ui_InGameMainUI.ChangeTimeSlider((_turn % 4) / 4f);

        if (_turn % 4 == 0)
        {
            isDay = !isDay;
            ChangeCameraBackgroundColor();

            foreach(var card in CardManager.instance.cardQueue)
            {
                if(isDay)
                    card.GetComponent<SpriteRenderer>().sprite = tileSprite[0];
                else
                    card.GetComponent<SpriteRenderer>().sprite = tileSprite[1];
            }
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
