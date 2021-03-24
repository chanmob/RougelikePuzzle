using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public enum Moveable
    {
        Movable,
        Immovable,
        None
    }

    protected const int ONUITIME = 2;

    private CardData _cardData;

    [SerializeField]
    private SpriteRenderer _spriteRender;

    public Vector2Int vector;

    protected Text _text;

    public int maxValue = 0;
    public int value = 0;
    protected int turnCount;

    protected float _clickTime = 0;

    public Define.CardType cardType = Define.CardType.None;
    public Moveable moveable = Moveable.None;

    private void Awake()
    {
        _spriteRender = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _text = GetComponentInChildren<Text>();
    }

    public void SetVector(int x, int y)
    {
        vector.x = x;
        vector.y = y;
    }

    public void SetValue(int value)
    {
        this.value = value;
        _text.text = value.ToString();
    }

    public abstract void OnDamage();

    public abstract void TurnEvent();

    public void GetDamage(int dmg)
    {
        OnDamage();
        SetValue(value - dmg);
    }

    public void SetData(CardData data)
    {
        _cardData = data;
        _spriteRender.sprite = data.cardSprite;

        if (data.isRandom)
            SetValue(Random.Range(data.randomMinValue, data.randomMaxValue + 1));
        else
            SetValue(data.fixValue);

        maxValue = value;
    }

    protected void ShowInfoUI()
    {

    }
}

