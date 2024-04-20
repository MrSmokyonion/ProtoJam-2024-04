using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance().onTime += RefreshTimer;          // ���߿� Ÿ�̸� ����� ��ũ��Ʈ/������Ʈ�� ����
    }

    /// <summary>
    /// Ÿ�̸� ���Ҷ� ȣ��Ǵ� �Լ�(�ڵ����� ��, �� �������)
    /// </summary>
    /// <param name="time">�ð�</param>
    void RefreshTimer(int time)
    {
        int mint = time / 60;
        int sec = time % 60;

        text.text = $"{mint:D2}:{sec:D2}";
    }

    /// <summary>
    /// Ÿ�̸� ���Ҷ� ȣ��Ǵ� �Լ�(��, �� �Է�)
    /// </summary>
    /// <param name="mint">��</param>
    /// <param name="sec">��</param>
    void RefreshTimer(int mint, int sec)
    {
        text.text = $"{mint:D2}:{sec:D2}";
    }
}
