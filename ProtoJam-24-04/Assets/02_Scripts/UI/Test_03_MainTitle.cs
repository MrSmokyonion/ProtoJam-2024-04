using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_03_MainTitle : MonoBehaviour
{
    MainMenuUI mainMenu;
    CreditUI credit;

    private void Start()
    {
        credit = FindAnyObjectByType<CreditUI>();
        mainMenu = FindAnyObjectByType<MainMenuUI>();   
    }

    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.S))
        {
            mainMenu.MoveCursor(1);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            mainMenu.MoveCursor(-1);
        }
        else if(Input.GetKeyDown(KeyCode.KeypadEnter)) 
        { 
            mainMenu.EnterButton();
        }

    }
}
