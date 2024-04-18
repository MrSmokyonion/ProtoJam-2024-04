using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuUI : MenuUI
{
    protected override void EnterButton()
    {
        switch(cursorIndex)
        {
            case 0:
                // ������ �ٽ��ϱ�
                SceneController.Ins.GoToScene(SceneType.Game);
                Debug.LogWarning("���� ������ �ٽý����ϴ� ���� �������� �ʾҽ��ϴ�.");
                break ;
            case 1:
                SceneController.Ins.GoToSceneWithoutLoad(SceneType.Main);
                Debug.LogWarning("���� ������ Ÿ��Ʋ ȭ������ ���� ��θ� �������� �ʾҽ��ϴ�.");
                break;

        }
    }
}
