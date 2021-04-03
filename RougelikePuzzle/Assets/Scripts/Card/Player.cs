using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Card
{
    public int weaponDurability;

    public Define.WeaponType weaponType = Define.WeaponType.None;

    [SerializeField]
    private Text _text_Durability;
    [SerializeField]
    private SpriteRenderer _weaponSprite;

    private void Start()
    {
        maxValue = value;
    }

    public override void OnDamage()
    {
    }

    public override void TurnEvent()
    {
    }

    public override void ReturnCard()
    {
    }

    public void OnMouseDown()
    {
        _clickTime = Time.time;
    }

    public void OnMouseUp()
    {
        if (Time.time - _clickTime >= ONUITIME)
        {

        }
    }

    public void PlayerGetDamage(int damage)
    {
        OnDamageEvent(damage);
    }

    public void TakeDamage(int damage)
    {
        if (weaponDurability > 0)
        {
            weaponDurability -= damage;

            if (weaponDurability <= 0)
            {
                value += weaponDurability;

                if (value <= 0)
                {

                }

                weaponDurability = 0;
                weaponType = Define.WeaponType.None;
            }
        }
        else
        {
            value -= damage;

            if (value <= 0)
            {

            }
        }
    }

    public void PlayerGetWeapon(Define.WeaponType weaponType, int durability)
    {
        this.weaponType = weaponType;
        weaponDurability = durability;

        GetWeaponEvent();

        _text_Durability.text = weaponDurability.ToString();
        _text_Durability.gameObject.SetActive(true);
    }

    public void PlayerHPTextRefresh()
    {
        _text.text = string.Format("{0}/{1}", value, maxValue);
        
        if (weaponDurability > 0)
            _text_Durability.text = weaponDurability.ToString();
        else
            _text_Durability.gameObject.SetActive(false);
    }

    protected virtual void GetWeaponEvent()
    {

    }

    protected virtual void OnDamageEvent(int damage)
    {
        TakeDamage(damage);
    }
}
