using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MenuUI
{
    /// <summary>
    /// 크래딧 패널을 열지 닫을지 여부(참이 되면 연다)
    /// </summary>
    bool isCreditOpen = false;

    /// <summary>
    /// 크래딧 패널
    /// </summary>
    CreditUI credit;

    protected override void Awake()
    {
        base.Awake();
        credit = GetComponentInChildren<CreditUI>();
    }

    /// <summary>
    /// 커서를 움직이는 함수
    /// </summary>
    /// <param name="add">-1 또는 1</param>
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
                // 게임 씬으로 전환
                // GoToScene();
                Debug.LogWarning("이동할 씬이 아직 구현되지 않았습니다.");
                break;
            case 1:
                // 크래딧 패널 띄우기
                isCreditOpen = !isCreditOpen;
                credit.FadeInOut(isCreditOpen);
                break;
            case 2:
                // 게임 종료하기
                QuitGame();
                break;
        }
    }



    /// <summary>
    /// 게임을 종료하는 함수
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        Debug.Log("게임 종료!");
#else   
        Application.Quit();
#endif
    }


}
