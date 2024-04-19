using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Reciepe Table Object")]
    public ReciepeTable reciepeTable;

    [Header("Variable")]
    public float startTimerLimit = 60f;
    public float timer { get; private set; }
    [SerializeField] private int score;
    public int Score { get { return score; } private set { score = value; } }
    public List<Chair> craftedChairList;

    #region singleton

    private static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public static GameManager Instance()
    {
        if(instance == null)
        {
            return null;
        }
        return instance;
    }

    #endregion


    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        //���� ����
        score = 0;
        craftedChairList = new List<Chair>();

        //Ÿ�̸� ����
        timer = startTimerLimit;
        StartCoroutine(OnTimerStart());
    }

    public void AddScore(Chair _craftedChair, int _score = 1)
    {
        craftedChairList.Add(_craftedChair);
        Score += score;
    }


    public void EndGame()
    {
        Debug.Log("End");
    }

    IEnumerator OnTimerStart()
    {
        yield return null;

        while (true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                break;
            }
            yield return null;
        }
        EndGame();
        yield return null;
    }
}
