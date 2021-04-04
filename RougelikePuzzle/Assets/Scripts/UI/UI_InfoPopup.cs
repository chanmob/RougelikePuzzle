using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InfoPopup : MonoBehaviour
{
    [SerializeField]
    private Image _image_Sprite;
    [SerializeField]
    private Text _text_InfoName;
    [SerializeField]
    private Text _text_InfoContent;

    private CardData _infoData;

    private void OnEnable()
    {
        if(_infoData != null)
        {
            _image_Sprite.sprite = _infoData.cardSprite;
            _text_InfoName.text = _infoData.cardName;
            _text_InfoContent.text = _infoData.cardInfo;
        }
    }

    public void SetData(CardData data)
    {
        _infoData = data;
    }

    public void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
