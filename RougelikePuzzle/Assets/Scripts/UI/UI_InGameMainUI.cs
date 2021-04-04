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

    }

    public void OnSettingUI()
    {

    }
}
