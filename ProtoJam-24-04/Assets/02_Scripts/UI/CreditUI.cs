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
    /// ��ũ���� ���̵� �ƿ�/�� ��Ű�� �Լ�
    /// </summary>
    /// <param name="isOpen">��ũ���� ���� ������ ����</param>
    public void FadeInOut(bool isOpen)
    {
        canvasGroup.DOFade(isOpen ? 1 : 0, fadeTime);
    }
}
