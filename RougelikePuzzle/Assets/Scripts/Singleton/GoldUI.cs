using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GoldUI : MonoBehaviour
{
	[SerializeField] private Text _goldText;
	private int beforeGold;
	DG.Tweening.Core.TweenerCore<int, int, DG.Tweening.Plugins.Options.NoOptions> RefreshTween;
	private void Start() {
		beforeGold = OutGameManager.instance._GoldData._Gold;
		OutGameManager.instance._GoldData.OnGoldChangedEvent += UIGoldTextRefresh;
		UIGoldTextRefresh();
	}
	private void OnDestroy() {
		if(OutGameManager.instance)
			OutGameManager.instance._GoldData.OnGoldChangedEvent -= UIGoldTextRefresh;
	}
	public void UIGoldTextRefresh() {
		RefreshTween.Kill();
		//_goldText.text = string.Format("{0}", OutGameManager.instance._GoldData._Gold);
		int newGold = OutGameManager.instance._GoldData._Gold;
		RefreshTween = DOTween.To(() => beforeGold, x => { beforeGold = x; _goldText.text = string.Format("{0}", beforeGold); },
			newGold, 0.5f);
	}
}
