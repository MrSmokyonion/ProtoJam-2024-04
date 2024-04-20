using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultData : MonoBehaviour
{
    public List<Chair> chairs;

    #region singleton

    private static ResultData instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public static ResultData Instance()
    {
        if (instance == null)
        {
            return null;
        }
        return instance;
    }

    #endregion

    public void DestroyResultData()
    {
        Destroy(this.gameObject);
    }
}
