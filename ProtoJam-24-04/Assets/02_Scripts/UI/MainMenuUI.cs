using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MenuUI
{
    /// <summary>
    /// ũ���� �г��� ���� ������ ����(���� �Ǹ� ����)
    /// </summary>
    bool isCreditOpen = false;

    /// <summary>
    /// ũ���� �г�
    /// </summary>
    CreditUI credit;

    protected override void Awake()
    {
        base.Awake();
        credit = GetComponentInChildren<CreditUI>();
    }

    /// <summary>
    /// Ŀ���� �����̴� �Լ�
    /// </summary>
    /// <param name="add">-1 �Ǵ� 1</param>
    protected override void MoveCursor(int add)
    {
        if (!cursor.gameObject.activeSelf)
        {
            EnableCursor();
        }
        else if (!isCreditOpen)
        {
            cursorIndex = Mathf.Clamp(cursorIndex + add, 0, buttons.Length - 1);
            cursor.transform.DOMoveY(buttons[cursorIndex].transform.position.y, cursorMoveDuration);
        }
    }


    protected override void EnterButton()
    {
        switch (cursorIndex)
        {
            case 0:
                // ���� ������ ��ȯ
                // GoToScene();
                Debug.LogWarning("�̵��� ���� ���� �������� �ʾҽ��ϴ�.");
                break;
            case 1:
                // ũ���� �г� ����
                isCreditOpen = !isCreditOpen;
                credit.FadeInOut(isCreditOpen);
                break;
            case 2:
                // ���� �����ϱ�
                QuitGame();
                break;
        }
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
