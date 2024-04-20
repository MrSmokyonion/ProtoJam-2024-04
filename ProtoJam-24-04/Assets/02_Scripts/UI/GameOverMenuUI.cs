using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuUI : MenuUI
{
    ResultChairLoader resultChairLoader;

    private void Start()
    {
        resultChairLoader = FindAnyObjectByType<ResultChairLoader>();
    }

    protected override void EnterButton()
    {
        switch(cursorIndex)
        {
            case 0:
                // ������Ʈ Ÿ�� ���������� �̵�
                resultChairLoader.MoveLeft();
                break;
            case 1:
                // ������ �ٽ��ϱ�
                SceneController.Ins.GoToScene(SceneType.Game);
                break ;
            case 2:
                // �������� ���ư���
                SceneController.Ins.GoToSceneWithoutLoad(SceneType.Main);
                break;
            case 3:
                // ������Ʈ Ÿ�� �������� �̵�
                resultChairLoader.MoveRight();
                break;

        }
    }
}
