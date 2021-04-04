using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
	private int _gold;
	public int _Gold {
		get { return _gold; }
		set { _gold = value; }
	}
	public UserData() {
		_gold = 0;
	}
}
