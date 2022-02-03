using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    Menu gameOverMenu;
    Menu escMenu;
    public static KeyCode escButton = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape) && !escMenu.open && !gameOverMenu.open) OpenEscMenu();
        //else if (Input.GetKeyDown(KeyCode.Escape) && escMenu.open && !gameOverMenu.open) CloseEscMenu();
    }

    void OpenEscMenu() 
    {
        PauseGame();
        escMenu.Open();
    }

    void CloseEscMenu() 
    {        
        escMenu.Close();
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
