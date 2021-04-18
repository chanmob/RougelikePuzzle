using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RandomEvent : MonoBehaviour
{
    [SerializeField]
    private RandomEvent randomEvent;

    public Text text_Title;
    public Text[] texts_Button;

    [SerializeField]
    private Button[] _buttons;

    private void OnDisable()
    {
        randomEvent = null;
    }

    public void SetRandomEvent(RandomEvent re)
    {
        randomEvent = re;

        int buttonLen = _buttons.Length;

        for (int i = 0; i < buttonLen; i++)
        {
            Button btn = _buttons[i];

            btn.onClick.RemoveAllListeners();
            btn.gameObject.SetActive(false);
        }

        int eventLength = randomEvent.button.Length;

        for(int i = 0; i < eventLength; i++)
        {
            Button btn = _buttons[i];

            text_Title.text = randomEvent.eventTitle;
            texts_Button[i].text = randomEvent.button[i];

            switch (i)
            {
                case 0:
                    btn.onClick.AddListener(() => randomEvent.FirstAction());
                    break;
                case 1:
                    btn.onClick.AddListener(() => randomEvent.SecondAction());
                    break;
                case 2:
                    btn.onClick.AddListener(() => randomEvent.ThirdAction());
                    break;
                case 3:
                    btn.onClick.AddListener(() => randomEvent.FourthAction());
                    break;
            }

            btn.gameObject.SetActive(true);
        }
    }
}
