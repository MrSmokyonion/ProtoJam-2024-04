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
        GameManager.Instance().onTime += RefreshTimer;          // 나중에 타이머 담당할 스크립트/오브젝트과 연결
    }

    /// <summary>
    /// 타이머 변할때 호출되는 함수(자동으로 분, 초 계산해줌)
    /// </summary>
    /// <param name="time">시간</param>
    void RefreshTimer(int time)
    {
        int mint = time / 60;
        int sec = time % 60;

        text.text = $"{mint:D2}:{sec:D2}";
    }

    /// <summary>
    /// 타이머 변할때 호출되는 함수(분, 초 입력)
    /// </summary>
    /// <param name="mint">분</param>
    /// <param name="sec">초</param>
    void RefreshTimer(int mint, int sec)
    {
        text.text = $"{mint:D2}:{sec:D2}";
    }
}
