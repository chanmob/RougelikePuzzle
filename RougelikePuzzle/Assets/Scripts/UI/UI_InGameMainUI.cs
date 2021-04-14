using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameMainUI : MonoBehaviour
{
    [SerializeField]
    private Text _text_Floor;
    [SerializeField]
    private Text _text_Coin;

    [SerializeField]
    private Slider _slider_Time;

    public void ChangeTimeSlider(float value)
    {
        _slider_Time.value = value;
    }

    public void SellWeapon()
    {
        if(InGameManager.instance.player.weaponType != Define.WeaponType.None)
        {
            InGameManager.instance.player.weapon = null;
            InGameManager.instance.player.weaponType = Define.WeaponType.None;
            InGameManager.instance.player.weaponDurability = 0;
            InGameManager.instance.player.PlayerHPTextRefresh();
        }
    }

    public void OnSettingUI()
    {

    }
}
