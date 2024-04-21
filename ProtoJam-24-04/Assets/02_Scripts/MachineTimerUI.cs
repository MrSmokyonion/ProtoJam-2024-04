using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineTimerUI : MonoBehaviour
{
    public Slider sliderRef;
    private float timerLimit;

    private void Start()
    {
        StartTimer(3.0f);
    }

    public void StartTimer(float _timer)
    {
        timerLimit = _timer;
        sliderRef.maxValue = _timer;
        sliderRef.minValue = 0;
        StartCoroutine(OnTimerStart());
    }

    IEnumerator OnTimerStart()
    {
        yield return null;

        float _curTime = 0f;
        while(true)
        {
            _curTime += Time.deltaTime;
            sliderRef.value = _curTime;
            if( _curTime > timerLimit )
            {
                break;
            }
            yield return null;
        }
        gameObject.SetActive( false );
    }
}
