using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuUI : MenuUI
{
    protected override void EnterButton()
    {
        switch(cursorIndex)
        {
            case 0:
                // ������ �ٽ��ϱ�
                // GoToScene(SceneManager.sceneCount);
                Debug.LogWarning("���� ������ �ٽý����ϴ� ���� �������� �ʾҽ��ϴ�.");
                break ;
            case 1:
                // Ÿ��Ʋ ȭ������ ����
                Debug.LogWarning("���� ������ Ÿ��Ʋ ȭ������ ���� ��θ� �������� �ʾҽ��ϴ�.");
                break;

        }
    }
}
