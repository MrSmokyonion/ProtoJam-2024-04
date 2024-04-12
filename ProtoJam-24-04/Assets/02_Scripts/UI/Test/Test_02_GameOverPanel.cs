using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_02_GameOverPanel : MonoBehaviour
{
    GameOverMenuUI gameOverPanel;

    private void Start()
    {
        gameOverPanel = FindAnyObjectByType<GameOverMenuUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameOverPanel.TestMoveCursor(1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gameOverPanel.TestMoveCursor(-1);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            gameOverPanel.TestEnterButton();
        }

    }
}
