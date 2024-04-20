using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    /// <summary>
    /// ���� Ŀ���� ���õ� ��ư�� �ε���
    /// </summary>
    protected int cursorIndex;

    /// <summary>
    /// Ŀ���� �����̴µ� �ҿ�Ǵ� �ð�
    /// </summary>
    public float cursorMoveDuration = 0.1f;

    /// <summary>
    /// ���� �޴��� �ִ� Ŀ��
    /// </summary>
    protected CursorUI cursor;

    /// <summary>
    /// ���� �޴��� �ִ� ��� ��ư��
    /// </summary>
    protected ButtonUI[] buttons;


    protected virtual void Awake()
    {
        cursor = GetComponentInChildren<CursorUI>();
        buttons = GetComponentsInChildren<ButtonUI>();
    }

    /// <summary>
    /// Ŀ���� �����̴� �Լ�
    /// </summary>
    /// <param name="add">-1 �Ǵ� 1</param>
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
    /// Ȯ�� ��ư ���� �� Ŀ�� �ε����� ���� �ൿ ����
    /// </summary>
    protected virtual void EnterButton()
    {

    }



//#if UNITY_EDITOR
    //������ �׽�Ʈ �ڵ�--------------
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
