using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Reference")]
    public TimerUI timerUI;
    public GameObject resultDataPrefab;
    public ItemSpawnCanon itemSpawnCanon;

    [Header("Variable")]
    public float startTimerLimit = 60f;
    public float timer { get; private set; }
    [SerializeField] private int score;
    public int Score { get { return score; } private set { score = value; } }
    public List<Chair> craftedChairList;

    public System.Action<int> onTime;

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
        //변수 설정
        score = 0;
        //craftedChairList = new List<Chair>();

        //타이머 설정
        timer = startTimerLimit;
        StartCoroutine(OnTimerStart());
    }

    public void AddScore(Chair _craftedChair, int _score = 1)
    {
        craftedChairList.Add(_craftedChair);
        Score += score;
    }

    public void RemoveItemOnce(Item.ItemType _type)
    {
        itemSpawnCanon.RemoveItemOnce(_type);
    }


    public void EndGame()
    {
        GameObject _obj = Instantiate(resultDataPrefab);
        _obj.GetComponent<ResultData>().chairs = craftedChairList;
        SceneManager.LoadScene(2);
    }

    IEnumerator OnTimerStart()
    {
        yield return null;
        onTime.Invoke((int)timer);

        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1;
            onTime.Invoke((int)timer);
            if (timer <= 0)
            {
                timer = 0;
                break;
            }
        }
        EndGame();
        yield return null;
    }
}
