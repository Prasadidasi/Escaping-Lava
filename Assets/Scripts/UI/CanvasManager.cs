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

    [SerializeField] GameObject playerController;
    static Rigidbody rb;
    static CharacterLook character;

    public MenuActions menuControls;
    private InputAction pause;
    private InputAction click;

    
    private void Awake()
    {
        Instance = this;

        escMenu = transform.GetChild(0).GetComponent<Menu>();
        gameOverMenu = transform.GetChild(1).GetComponent<Menu>();
        goalMenu = transform.GetChild(2).GetComponent<Menu>();

        character = (CharacterLook)playerController.GetComponent("CharacterLook");
        rb = playerController.GetComponent<Rigidbody>();
        
        menuControls = new MenuActions();
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
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        character.mouseHorizontalSensitivity = 0;
        character.mouseVerticalSensitivity = 0;
    }

    public void UnFreezeCharacter()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
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
