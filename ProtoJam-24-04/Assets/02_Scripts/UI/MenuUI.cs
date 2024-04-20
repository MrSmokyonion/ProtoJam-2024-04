using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    /// <summary>
    /// 현재 커서가 선택된 버튼의 인덱스
    /// </summary>
    protected int cursorIndex;

    /// <summary>
    /// 커서가 움직이는데 소요되는 시간
    /// </summary>
    public float cursorMoveDuration = 0.1f;

    /// <summary>
    /// 현재 메뉴에 있는 커서
    /// </summary>
    protected CursorUI cursor;

    /// <summary>
    /// 현재 메뉴에 있는 모든 버튼들
    /// </summary>
    protected ButtonUI[] buttons;


    protected virtual void Awake()
    {
        cursor = GetComponentInChildren<CursorUI>();
        buttons = GetComponentsInChildren<ButtonUI>();
    }

    /// <summary>
    /// 커서를 움직이는 함수
    /// </summary>
    /// <param name="add">-1 또는 1</param>
    protected virtual void MoveCursor(int add)
    {
        if (!cursor.gameObject.activeSelf)
        {
            EnableCursor();
        }
        else 
        {
            cursorIndex = Mathf.Clamp(cursorIndex + add, 0, buttons.Length - 1);
            cursor.transform.DOMove(buttons[cursorIndex].transform.position, cursorMoveDuration);
            cursor.GetComponent<RectTransform>().DOSizeDelta(buttons[cursorIndex].GetComponent<RectTransform>().sizeDelta, cursorMoveDuration);
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

    /// <summary>
    /// 확인 버튼 누를 때 커서 인덱스에 따른 행동 설정
    /// </summary>
    protected virtual void EnterButton()
    {

    }



//#if UNITY_EDITOR
    //에디터 테스트 코드--------------
    public void TestMoveCursor(int a)
    {
        MoveCursor(a);
    }

    public void TestEnterButton()
    {
        EnterButton();
    }
//#endif
}
