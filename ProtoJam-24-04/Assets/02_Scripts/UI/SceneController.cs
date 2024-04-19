using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType : int
{
    Main,
    Game,
    Result,
    Load
}

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// �� ��ü�� ó�� ��������� Ȯ���ϴ� ����
    /// </summary>
    private bool initialized;

    private static SceneController instance;
    public static SceneController Ins
    {
        // get => ins ?? (ins = new SceneController());
        get
        {
            if (instance == null)    // instance�� ����� �ȉ��� ��
            {
                SceneController singleton = FindObjectOfType<SceneController>();
                if (singleton == null)  // ���� ������ ���� ������Ʈ ����
                {
                    GameObject obj = new GameObject();
                    obj.name = $"{typeof(SceneController).Name} Singleton";
                    singleton = obj.AddComponent<SceneController>();
                }

                instance = singleton;       // intance�� ã�Ұų� ������� ��ü ����
                DontDestroyOnLoad(instance.gameObject);     //���� �������� ���� ���� �ʰ� ����
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)  // �ڱ��ڽ��� ������µ� instance�� ���� ��
        {
            // ���� ��ġ�Ǿ� �ִ� ù��° �̱����� �ڱ� �ڽ����� ���
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            // instance�� �ִµ� �װ� �ڱ� �ڽ��� �ƴ� ��
            if (instance != this) Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!initialized)   // ��ü�� ó������ ������ ��
        {
            OnPreInitalize();
        }

        if (mode != LoadSceneMode.Additive)     // �ε��� ���� �񵿱� ����� ����
        {
            OnInitalize();
        }
    }

    /// <summary>
    /// �̱����� ��������� ���� �� �ѹ��� ȣ��� �ʱ�ȭ �Լ�
    /// </summary>
    protected virtual void OnPreInitalize()
    {
        initialized = true;
    }

    /// <summary>
    /// �̱����� ��������� ���� ȣ��ɶ�(�ݺ��ɼ��� ����)
    /// </summary>
    protected virtual void OnInitalize()
    {
        isLoading = false;
    }


    //----------------------------------------

    /// <summary>
    /// ���� ���� ��
    /// </summary>
    public SceneType nextScene = SceneType.Main;

    /// <summary>
    /// �ε� �� Ȱ��ȭ �ɶ� ������ ��
    /// </summary>
    public Scene beforeScene;

    /// <summary>
    /// �ε� ���� Ȱ��ȭ ������ Ȯ���ϴ� ����
    /// </summary>
    private bool isLoading = false;

    public void GoToScene(int id)
    {
        if (isLoading) return;

        nextScene = (SceneType) id;

        beforeScene = SceneManager.GetActiveScene();
        Debug.Log($"current Scene : {beforeScene.name}");

        isLoading = true;

        SceneManager.LoadScene((int)SceneType.Load, LoadSceneMode.Additive);
    }

    public void GoToScene(SceneType sceneType)
    {
        GoToScene((int)sceneType);
    }

    public void GoToSceneWithoutLoad(SceneType sceneType)
    {
        SceneManager.LoadScene((int)sceneType);
    }
}
