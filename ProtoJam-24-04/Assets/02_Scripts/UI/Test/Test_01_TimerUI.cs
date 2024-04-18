using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_01_TimerUI : MonoBehaviour
{

    public float timeLeft = 120.0f;
    public float TimeLeft
    {
        get => timeLeft;
        set
        {
            timeLeft = value;
            int temp = Mathf.CeilToInt(timeLeft);
            
            if (currentTime != temp)
            {
                currentTime = temp;
                onTime?.Invoke(currentTime);
            }
        }
    }

    int currentTime = 120;
    public System.Action<int> onTime;

    private void Start()
    {
        // 씬 넘어가는거 테스트 해볼 코드
        StartCoroutine(TestStart());
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;

        
    }

    IEnumerator TestStart()
    {
        yield return new WaitForSeconds(5.0f);
        SceneController.Ins.GoToSceneWithoutLoad(SceneType.Result);
    }
}
