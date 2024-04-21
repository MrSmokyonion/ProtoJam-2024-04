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
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gameOverPanel.TestMoveCursor(-1);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            gameOverPanel.TestEnterButton();
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        }

    }
}
