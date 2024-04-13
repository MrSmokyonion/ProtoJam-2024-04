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
                // 게임을 다시하기
                // GoToScene(SceneManager.sceneCount);
                Debug.LogWarning("아직 게임을 다시시작하는 씬을 연결하지 않았습니다.");
                break ;
            case 1:
                // 타이틀 화면으로 가기
                Debug.LogWarning("아직 게임을 타이틀 화면으로 가는 경로를 연결하지 않았습니다.");
                break;

        }
    }
}
