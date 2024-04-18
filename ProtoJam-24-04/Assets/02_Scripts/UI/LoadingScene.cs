using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    /// <summary>
    /// 다음에 로딩할 씬의 이름
    /// </summary>
    public SceneType nextSceneType = SceneType.Main;

    /// <summary>
    /// 비동기 명령 처리용 변수
    /// </summary>
    AsyncOperation async;

    /// <summary>
    /// 로딩 바의 Value를 설정(로딩이 너무 빨라서 수동으로 조절하고자 추가한 변수, 속도 조절은 loadingBarSpeed으로함)
    /// </summary>
    float loadRatio = 0;

    /// <summary>
    /// 로딩 바가 증가하는 속도(실제 다음 넘어가는 버튼이 활성화 되는데 이 변수가 조절함)
    /// </summary>
    public float loadingBarSpeed = 1.0f;

    /// <summary>
    /// 로딩이 다 되었는지 체크
    /// </summary>
    bool loadingDone = false;

    /// <summary>
    /// 로딩 텍스트 제어하는 코루틴
    /// </summary>
    IEnumerator loadingTextCoroutine;

    /// <summary>
    /// 로딩 진행상황을 나타내는 슬라이더
    /// </summary>
    Slider loadSlider;

    /// <summary>
    /// 로딩 텍스트
    /// </summary>
    TextMeshProUGUI loadingText;

    /// <summary>
    /// 로딩 완료시 뜨는 텍스트(클릭하시오 같은거)
    /// </summary>
    CanvasGroup loadingComplateText;

    CanvasGroup loadTextPanel;

    private void Awake()
    {
        loadingTextCoroutine = loadingChangeText();
        loadTextPanel = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        loadingText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        loadSlider = transform.GetChild(1).GetComponent<Slider>();
        loadingComplateText = transform.GetChild(2).GetComponent<CanvasGroup>();

        nextSceneType = SceneController.Ins.nextScene;
        Debug.Log($"다음 씬 설정 : {nextSceneType}");

        // 페이드 패널
        loadTextPanel.DOFade(1.0f, 0.5f);

        StartCoroutine(loadingTextCoroutine);
        StartCoroutine(LoadScene());
    }

    private void GoToNextScene()
    {
        if(loadingDone)
        {
            async.allowSceneActivation = true;  
        }
    }

    private void Update()
    {
        // 로딩바가 한번에 올라가는 것이 아닌 천천히 올라가게 함
        if (loadSlider.value < loadRatio)
        {
            loadSlider.value += Time.deltaTime * loadingBarSpeed;
        }

        if(loadingDone && Input.anyKeyDown)
        {
            GoToNextScene();
        }
    }

    IEnumerator LoadScene()
    {
        loadSlider.value = 0;
        loadingComplateText.alpha = 0;
        loadRatio = 0;

        async = SceneManager.LoadSceneAsync((int) nextSceneType);
        async.allowSceneActivation = false;

        while (loadRatio < 1.0f)
        {
            loadRatio = async.progress + 0.1f;      

            yield return null;
        }

        yield return new WaitForSeconds((loadRatio - loadSlider.value) / loadingBarSpeed);      // 실제 로딩이 빨라 게이지가 늦게 찰 경우 다 찰때까지 기다림

        loadingDone = true;

        StopCoroutine(loadingTextCoroutine);        // '로딩중....' 텍스트 코루틴 종료(자체적으로 종료하겠지만 waitTime때문에 바로 끊기)

        loadingText.text = "Loading\nComplete";     // 메인 텍스트 변경

        // 아무키나 누르시오 등장
        // loadingComplateText.DOFade(1.0f, 1.0f);          // Dotween으로 하니 애니메이션이 완료되기전에 씬이 넘어가면 Dotween Warning이 뜸(제어대상 missing 경고)
        StartCoroutine(ShowNextText());
    }

    IEnumerator loadingChangeText()
    {
        float waitTime = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(waitTime);

        // string을 돌려쓰면 가비지가 많이 생길수 있기 때문에 미리 배열로 만들어 둠
        string[] texts =
        {
            "Loading",
            "Loading .",
            "Loading . .",
            "Loading . . .",
            "Loading . . . .",
            "Loading . . . . ."
        };

        int index = 0;
        while (!loadingDone)
        {
            loadingText.text = texts[index];
            index++;
            index %= texts.Length;

            yield return wait;
        }
    }

    IEnumerator ShowNextText()
    {
        while (loadingComplateText.alpha < 1.0f)
        {
            loadingComplateText.alpha += Time.deltaTime;
            yield return null;
        }
    }
}
