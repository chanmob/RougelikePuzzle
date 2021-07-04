using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaInfo : MonoBehaviour
{
	[SerializeField] private Text costText;
	[SerializeField] private GachaResult gachaResult;
	private int cost = 1000;

	public void SetInfo() {
		costText.text = cost.ToString();
	}

	public void OnPressGachaButton() {
		if(OutGameManager.instance._GoldData._Gold < cost) return;
		OutGameManager.instance._GoldData.AddGold(-cost);
		gachaResult.gameObject.SetActive(true);
		gachaResult.GachaAnimation();
		gameObject.SetActive(false);
	}
}
