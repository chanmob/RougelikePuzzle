using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GachaResult : MonoBehaviour
{
	[SerializeField] private Image Chest;
	[SerializeField] private Image MaskingTarget;
	[SerializeField] private GameObject GachaEffect;
	[SerializeField] private GameObject GachaResultFrame;
	[SerializeField] private Text RandomAmountText;

	public void GachaAnimation() {
		Chest.transform.DOKill();
		GachaEffect.SetActive(true);
		GachaResultFrame.SetActive(false);
		MaskingTarget.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
		MaskingTarget.DOColor(Color.white, 2.0f).OnComplete(OnGachaAnimationComplete);
		Chest.transform.rotation = Quaternion.AngleAxis(-10.0f, Vector3.forward);
		Chest.transform.DORotate(Vector3.forward * 10.0f, 0.2f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
	}

	public void OnGachaAnimationComplete() {
		GachaEffect.SetActive(false);
		GachaResultFrame.SetActive(true);
		GetCoin();
	}
	public void GetCoin() {
		int coinRandomValue = GetRandomAmount(0, 2000);
		RandomAmountText.text = string.Format("X {0}", coinRandomValue);
		OutGameManager.instance._GoldData.AddGold(coinRandomValue);
	}
	public int GetRandomAmount(int minValue, int maxValue) {
		return Random.Range(minValue, maxValue + 1);
	}
	
}
