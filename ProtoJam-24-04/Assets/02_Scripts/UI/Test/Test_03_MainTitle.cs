using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_03_MainTitle : MonoBehaviour
{
    MainMenuUI mainMenu;

    private void Start()
    {
        mainMenu = FindAnyObjectByType<MainMenuUI>();   
    }

    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            mainMenu.TestMoveCursor(1);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            mainMenu.TestMoveCursor(-1);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        }
        else if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            mainMenu.TestEnterButton();
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        }

    }
}
