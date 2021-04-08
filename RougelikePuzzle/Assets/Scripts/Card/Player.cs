using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Card
{
    public int weaponDurability;

    public Define.WeaponType weaponType = Define.WeaponType.None;

    public Weapon weapon;

    [SerializeField]
    private Text _text_Durability;
    [SerializeField]
    private SpriteRenderer _weaponSprite;

    private void Start()
    {
        maxValue = value;
    }

    public override void OnDamage(int dmg, Card card)
    {
        if (weaponType != Define.WeaponType.None)
            weapon.WeaponEventBeforeGetDamage(card);

        OnDamageEvent(dmg, card);
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

    public void TakeDamage(int damage, Card card)
    {
        if (weaponDurability > 0)
        {
            weaponDurability -= damage;

            if (weaponDurability < 0)
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

        if (weaponType != Define.WeaponType.None)
            weapon.WeaponEventAfterGetDamage(card);
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

    protected virtual void OnDamageEvent(int damage, Card card)
    {
        TakeDamage(damage, card);
    }
}
