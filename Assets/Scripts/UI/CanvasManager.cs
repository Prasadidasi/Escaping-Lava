using System.Collections;
using System.Collections.Generic;
using ECM2.Components;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField] int levelNumber;

    static Menu gameOverMenu;
    static Menu escMenu;
    static Menu goalMenu;

    GameObject playerController;
    CharacterLook character;

    public MenuActions menuControls;
    private InputAction pause;
    private InputAction click;

    
    private void Awake()
    {
        escMenu = transform.GetChild(0).GetComponent<Menu>();
        gameOverMenu = transform.GetChild(1).GetComponent<Menu>();
        goalMenu = transform.GetChild(2).GetComponent<Menu>();
        
        menuControls = new MenuActions();
        Instance = this;
    }

    private void OnEnable()
    {
        
        pause = menuControls.Buttons.Pause;
        pause.Enable();
        pause.performed += Pause;
    }

    private void OnDisable()
    {
        pause.Disable();
    }

    void Update()
    {
        
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if (!escMenu.open && !gameOverMenu.open && !goalMenu.open) OpenEscMenu(); 
        else if (escMenu.open) CloseEscMenu();
    }

    public void OpenEscMenu() 
    {
        PauseGame();
        escMenu.Open();
    }

    public void CloseEscMenu() 
    { 
        escMenu.Close();
        ResumeGame();       
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame ()
    {
        FreezeCharacter();
        //Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        UnFreezeCharacter();
        //Time.timeScale = 1;
    }

    public void FreezeCharacter()
    {
        playerController = GameObject.Find("First Person Character");
        character = (CharacterLook)playerController.GetComponent("CharacterLook");
        character.mouseHorizontalSensitivity = 0;
        character.mouseVerticalSensitivity = 0;
    }

    public void UnFreezeCharacter()
    {
        playerController = GameObject.Find("First Person Character");
        character = (CharacterLook)playerController.GetComponent("CharacterLook");
        character.mouseHorizontalSensitivity = (float) 0.1;
        character.mouseVerticalSensitivity = (float) 0.1;
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(levelNumber+1);
    }
}
