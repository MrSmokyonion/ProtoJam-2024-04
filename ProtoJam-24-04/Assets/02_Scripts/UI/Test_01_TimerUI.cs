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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
    }
}
