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

    public void DecreaseWeaponDurability(int damage)
    {
        weaponDurability -= damage;

        if(weaponDurability <= 0)
        {
            weaponDurability = 0;
            weaponType = Define.WeaponType.None;
        }   
    }
}
