using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutGameManager : Singleton<OutGameManager>
{
	private GoldData _goldData;
	public GoldData _GoldData {
		get { return _goldData; }
	}

	protected override void OnAwake() {
		_goldData = new GoldData();
	}
}
