using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_OutGameAddGold : MonoBehaviour
{
	[SerializeField] private int _addCount = 1;
	public void OnAddGold() {
		OutGameManager.instance._GoldData.AddGold(_addCount);
	}
}
