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
                // 오브젝트 타겟 오른쪽으로 이동
                resultChairLoader.MoveLeft();
                break;
            case 1:
                // 게임을 다시하기
                SceneController.Ins.GoToScene(SceneType.Game);
                break ;
            case 2:
                // 메인으로 돌아가기
                SceneController.Ins.GoToSceneWithoutLoad(SceneType.Main);
                break;
            case 3:
                // 오브젝트 타겟 왼쪽으로 이동
                resultChairLoader.MoveRight();
                break;

        }
    }
}
