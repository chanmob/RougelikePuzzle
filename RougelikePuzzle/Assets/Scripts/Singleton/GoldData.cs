using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldData
{
	private int _gold = 0;
	public int _Gold {
		get { return _gold; }
		set { _gold = value; }
	}
	public System.Action OnGoldChangedEvent;
	public void AddGold(int getGold) {
		_gold += getGold;
		OnGoldChangedEvent?.Invoke();
	}
	public void ResetGold() {
		_gold = 0;
		OnGoldChangedEvent?.Invoke();
	}
}
