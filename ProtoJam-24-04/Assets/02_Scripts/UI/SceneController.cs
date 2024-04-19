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
    /// 이 객체가 처음 생성됬는지 확인하는 변수
    /// </summary>
    private bool initialized;

    private static SceneController instance;
    public static SceneController Ins
    {
        // get => ins ?? (ins = new SceneController());
        get
        {
            if (instance == null)    // instance이 등록이 안됬을 때
            {
                SceneController singleton = FindObjectOfType<SceneController>();
                if (singleton == null)  // 씬에 없으면 새로 오브젝트 생성
                {
                    GameObject obj = new GameObject();
                    obj.name = $"{typeof(SceneController).Name} Singleton";
                    singleton = obj.AddComponent<SceneController>();
                }

                instance = singleton;       // intance를 찾았거나 만들어진 객체 대입
                DontDestroyOnLoad(instance.gameObject);     //씬이 없어져도 삭제 되지 않게 설정
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)  // 자기자신이 생성됬는데 instance가 없을 때
        {
            // 씬에 배치되어 있는 첫번째 싱글톤을 자기 자신으로 등록
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            // instance가 있는데 그게 자기 자신이 아닐 때
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
        if (!initialized)   // 객체가 처음으로 설정될 때
        {
            OnPreInitalize();
        }

        if (mode != LoadSceneMode.Additive)     // 로딩씬 같은 비동기 방식은 무시
        {
            OnInitalize();
        }
    }

    /// <summary>
    /// 싱글톤이 만들어질때 최초 단 한번만 호출될 초기화 함수
    /// </summary>
    protected virtual void OnPreInitalize()
    {
        initialized = true;
    }

    /// <summary>
    /// 싱글톤이 만들어지고 씬이 호출될때(반복될수도 있음)
    /// </summary>
    protected virtual void OnInitalize()
    {
        isLoading = false;
    }


    //----------------------------------------

    /// <summary>
    /// 다음 열릴 씬
    /// </summary>
    public SceneType nextScene = SceneType.Main;

    /// <summary>
    /// 로딩 씬 활성화 될때 직전의 씬
    /// </summary>
    public Scene beforeScene;

    /// <summary>
    /// 로딩 씬이 활성화 중인지 확인하는 변수
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
