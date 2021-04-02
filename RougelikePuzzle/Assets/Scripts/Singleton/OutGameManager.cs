using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutGameManager : Singleton<OutGameManager>
{
    private int _gold = 0;
	private Text _goldText;

	private void Start() {
		_goldText = GameObject.Find("GoldText").GetComponent<Text>();
	}

	public void AddGold(int getGold) {
		_gold += getGold;
		UIGoldTextRefresh();
	}

	public int GetGold() {
		return _gold;
	}

	public void UIGoldTextRefresh() {
		_goldText.text = string.Format("Gold : {0}", _gold);
	}
}
