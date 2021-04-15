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

    public CardData cardData;

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
        _spriteRender.sprite = cardData.cardSprite;
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

        if (value > 0)
        {
            _text.gameObject.SetActive(false);
        }
        else
        {
            _text.gameObject.SetActive(true);
        }
    }

    public abstract void OnDamage(int dmg, Card card);

    public abstract void TurnEvent();

    public abstract void ReturnCard();

    public void GetDamage(int dmg, Card card)
    {
        OnDamage(dmg, card);
    }

    public void GetHeal(int heal, bool over = false)
    {
        int v = value + heal;

        if (over)
        {
            SetValue(v);
        }
        else
        {
            if (value > maxValue)
                return;

            if (v > maxValue)
            {
                SetValue(maxValue);
            }
            else
            {
                SetValue(v);
            }
        }
    }

    public void AddMaxValue(int inc, bool heal = false)
    {
        maxValue += inc;

        if (heal)
            GetHeal(inc);
        else
            GetHeal(0);
    }

    public void SetData()
    {
        int v = 0;

        if (cardData.isRandom)
            v = Random.Range(cardData.randomMinValue, cardData.randomMaxValue + 1);
        else
            v = cardData.fixValue;

        maxValue = v;
        SetValue(v);

        if (maxValue > 0)
        {
            _text.gameObject.SetActive(true);
        }
        else
        {
            _text.gameObject.SetActive(false);
        }

        ScaleAnimation();
    }

    protected void ShowInfoUI()
    {
        InGameUIManager.instance.ui_InfoPopup.SetData(cardData);
        InGameUIManager.instance.ui_InfoPopup.gameObject.SetActive(true);
    }

    public void ScaleAnimation()
    {
        transform.localScale = new Vector2(0, 0);
        transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }
}

