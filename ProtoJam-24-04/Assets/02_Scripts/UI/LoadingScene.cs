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
    /// ������ �ε��� ���� �̸�
    /// </summary>
    public SceneType nextSceneType = SceneType.Main;

    /// <summary>
    /// �񵿱� ��� ó���� ����
    /// </summary>
    AsyncOperation async;

    /// <summary>
    /// �ε� ���� Value�� ����(�ε��� �ʹ� ���� �������� �����ϰ��� �߰��� ����, �ӵ� ������ loadingBarSpeed������)
    /// </summary>
    float loadRatio = 0;

    /// <summary>
    /// �ε� �ٰ� �����ϴ� �ӵ�(���� ���� �Ѿ�� ��ư�� Ȱ��ȭ �Ǵµ� �� ������ ������)
    /// </summary>
    public float loadingBarSpeed = 1.0f;

    /// <summary>
    /// �ε��� �� �Ǿ����� üũ
    /// </summary>
    bool loadingDone = false;

    /// <summary>
    /// �ε� �ؽ�Ʈ �����ϴ� �ڷ�ƾ
    /// </summary>
    IEnumerator loadingTextCoroutine;

    /// <summary>
    /// �ε� �����Ȳ�� ��Ÿ���� �����̴�
    /// </summary>
    Slider loadSlider;

    /// <summary>
    /// �ε� �ؽ�Ʈ
    /// </summary>
    TextMeshProUGUI loadingText;

    /// <summary>
    /// �ε� �Ϸ�� �ߴ� �ؽ�Ʈ(Ŭ���Ͻÿ� ������)
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
        Debug.Log($"���� �� ���� : {nextSceneType}");

        // ���̵� �г�
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
        // �ε��ٰ� �ѹ��� �ö󰡴� ���� �ƴ� õõ�� �ö󰡰� ��
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

        yield return new WaitForSeconds((loadRatio - loadSlider.value) / loadingBarSpeed);      // ���� �ε��� ���� �������� �ʰ� �� ��� �� �������� ��ٸ�

        loadingDone = true;

        StopCoroutine(loadingTextCoroutine);        // '�ε���....' �ؽ�Ʈ �ڷ�ƾ ����(��ü������ �����ϰ����� waitTime������ �ٷ� ����)

        loadingText.text = "Loading\nComplete";     // ���� �ؽ�Ʈ ����

        // �ƹ�Ű�� �����ÿ� ����
        // loadingComplateText.DOFade(1.0f, 1.0f);          // Dotween���� �ϴ� �ִϸ��̼��� �Ϸ�Ǳ����� ���� �Ѿ�� Dotween Warning�� ��(������ missing ���)
        StartCoroutine(ShowNextText());
    }

    IEnumerator loadingChangeText()
    {
        float waitTime = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(waitTime);

        // string�� �������� �������� ���� ����� �ֱ� ������ �̸� �迭�� ����� ��
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
