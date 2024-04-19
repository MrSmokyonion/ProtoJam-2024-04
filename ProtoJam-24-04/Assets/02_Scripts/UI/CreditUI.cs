using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditUI : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public float fadeTime = 1.0f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// 스크린을 페이드 아웃/인 시키는 함수
    /// </summary>
    /// <param name="isOpen">스크린을 열지 닫을지 여부</param>
    public void FadeInOut(bool isOpen)
    {
        canvasGroup.DOFade(isOpen ? 1 : 0, fadeTime);
    }
}
