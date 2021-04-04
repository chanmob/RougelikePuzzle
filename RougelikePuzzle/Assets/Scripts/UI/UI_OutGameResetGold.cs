using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_OutGameResetGold : MonoBehaviour
{
	public void OnResetGold() {
		OutGameManager.instance._GoldData.ResetGold();
	}
}
