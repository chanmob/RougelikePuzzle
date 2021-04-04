using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutGameManager : Singleton<OutGameManager>
{
	private GoldData _goldData;
	private UserData _userData;
	private JsonLoader _jsonLoader;
	public GoldData _GoldData {
		get { return _goldData; }
	}

	protected override void OnAwake() {
		_goldData = new GoldData();
		_jsonLoader = new JsonLoader();
		_userData = _jsonLoader.Load();
		_goldData._Gold = _userData._Gold;
		_goldData.OnGoldChangedEvent += Save;
	}

	public void Save() {
		_userData._Gold = _goldData._Gold;
		_jsonLoader.Save(_userData);
	}
}
