using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    protected const int ONUITIME = 2;

    private SpriteRenderer _spriteRender;

    public Vector2Int vector;

    private Text _text;

    public int value = 0;

    public Define.CardType cardType = Define.CardType.None;

    private void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        _text = GetComponent<Text>();
        OnStart();
    }

    public abstract void OnStart();

    public abstract void OnDie();

    public void SetVector(int x, int y)
    {
        vector.x = x;
        vector.y = y;
    }

    public void SetValue(int value)
    {
        this.value = value;
        _text.text = value.ToString();

        if (value <= 0)
            OnDie();
    }

    public void GetDamage(int dmg)
    {
        SetValue(value - dmg);
    }
}

