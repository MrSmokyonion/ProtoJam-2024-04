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
                // 게임을 다시하기
                SceneController.Ins.GoToScene(SceneType.Game);
                break ;
            case 1:
                SceneController.Ins.GoToSceneWithoutLoad(SceneType.Main);
                break;

        }
    }
}
