using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class Card : MonoBehaviour
{
    public enum Moveable
    {
        Movable,
        Immovable,
        None
    }

    protected const int ONUITIME = 2;

    [SerializeField]
    private CardData _cardData;

    [SerializeField]
    protected SpriteRenderer _spriteRender;

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

        Canvas canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    private void Start()
    {
        _spriteRender.sprite = _cardData.cardSprite;
    }

    public void SetVector(int x, int y)
    {
        vector.x = x;
        vector.y = y;
    }

    public void SetValue(int value)
    {
        this.value = value;

        if (_text.gameObject.activeSelf)
            _text.text = string.Format("{0}/{1}", value, maxValue);
    }

    public abstract void OnDamage();

    public abstract void TurnEvent();

    public abstract void ReturnCard();

    public void GetDamage(int dmg)
    {
        OnDamage();
        SetValue(value - dmg);
    }

    public void SetData()
    {
        int v = 0;

        if (_cardData.isRandom)
            v = Random.Range(_cardData.randomMinValue, _cardData.randomMaxValue + 1);
        else
            v = _cardData.fixValue;

        maxValue = v;
        SetValue(v);

        if (maxValue == 0)
        {
            _text.gameObject.SetActive(false);
        }
        else
        {
            _text.gameObject.SetActive(true);
        }

        ScaleAnimation();
    }

    protected void ShowInfoUI()
    {

    }

    public void ScaleAnimation()
    {
        transform.localScale = new Vector2(0, 0);
        transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }
}

