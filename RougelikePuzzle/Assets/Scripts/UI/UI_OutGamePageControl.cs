using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UI_OutGamePageControl : MonoBehaviour
{
    [SerializeField]
    private UI_Page[] uiPages;
    private int recentPage;
    private Vector3[] uiPagePositions;
    [SerializeField]
    private Button[] pageChangeButtons;

    public void Awake() {
        uiPagePositions = new Vector3[uiPages.Length];
        for(int i = 0; i < uiPages.Length; i++) {
            uiPages[i].Init(i);
            uiPagePositions[i] = uiPages[i].transform.position;
		}

        ChangePageNoTween(2);
    }

    public void ChangePage(int TargetPage) {
        recentPage = TargetPage;
        for(int i = 0; i < uiPages.Length; i++) {
            uiPages[i].transform.DOMoveX(uiPagePositions[i].x - recentPage * Screen.width, 0.4f);
            pageChangeButtons[i].image.color = i == recentPage ? Color.gray : Color.white;
		}
	}
	
    public void ChangePageNoTween(int TargetPage) {
        recentPage = TargetPage;
        for (int i = 0; i < uiPages.Length; i++) {
            uiPages[i].transform.position = new Vector3(uiPagePositions[i].x - recentPage * Screen.width, uiPagePositions[i].y, uiPagePositions[i].z);
            pageChangeButtons[i].image.color = i == recentPage ? Color.gray : Color.white;
        }
    }

}