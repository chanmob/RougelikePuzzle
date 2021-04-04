using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
	[SerializeField] private Text _goldText;
	private void Start() {
		OutGameManager.instance._GoldData.OnGoldChangedEvent += UIGoldTextRefresh;
		UIGoldTextRefresh();
	}
	private void OnDestroy() {
		if(OutGameManager.instance)
			OutGameManager.instance._GoldData.OnGoldChangedEvent -= UIGoldTextRefresh;
	}
	public void UIGoldTextRefresh() {
		_goldText.text = string.Format("Gold : {0}", OutGameManager.instance._GoldData._Gold);
	}
}
