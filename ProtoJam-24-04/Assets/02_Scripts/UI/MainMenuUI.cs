using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public float cursorMoveDuration = 0.1f;

    int cursorIndex;


    CreditUI credit;
    CursorUI cursor;
    ButtonUI[] buttons;


    private void Awake()
    {
        credit = GetComponentInChildren<CreditUI>();
        cursor = GetComponentInChildren<CursorUI>();
        buttons = GetComponentsInChildren<ButtonUI>();
    }

    public void MoveCursor(int add)
    {
        if(!cursor.gameObject.activeSelf)
        {
            EnableCursor();
        }
        else if (!isCreditOpen)
        {
            cursorIndex = Mathf.Clamp(cursorIndex + add, 0, buttons.Length - 1);
            cursor.transform.DOMoveY(buttons[cursorIndex].transform.position.y, cursorMoveDuration);
        }
    }

    public void DisableCursor()
    {
        cursor.gameObject.SetActive(false);
    }

    public void EnableCursor()
    {
        cursor.gameObject.SetActive(true);
        MoveCursor(-10);
    }

    bool isCreditOpen = false;

    public void EnterButton()
    {
        switch (cursorIndex)
        {
            case 0:
                // GoToScene();
                break;
            case 1:
                isCreditOpen = !isCreditOpen;
                credit.FadeInOut(isCreditOpen);
                break;
            case 2:
                QuitGame();
                break;
        }
    }



    /// <summary>
    /// ���� �ҷ����� �Լ�(id)
    /// </summary>
    /// <param name="sceneId">�� id</param>
    public void GoToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    /// <summary>
    /// ���� �ҷ����� �Լ�(string)
    /// </summary>
    /// <param name="sceneName">�� �̸�</param>
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// ������ �����ϴ� �Լ�
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        Debug.Log("���� ����!");
#else   
        Application.Quit();
#endif
    }
}
