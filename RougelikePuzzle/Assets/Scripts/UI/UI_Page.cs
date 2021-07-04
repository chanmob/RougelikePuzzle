using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Page : MonoBehaviour
{
	[SerializeField]
	private RectTransform pageRectTransform;

	public void Init(int i) {
		pageRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
		pageRectTransform.position = new Vector3(i * Screen.width + Screen.width / 2, pageRectTransform.position.y, pageRectTransform.position.z);
	}
}
