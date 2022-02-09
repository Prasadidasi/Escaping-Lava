using ECM2.Components;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField] int levelNumber;

    
    public TMP_Text countDownText;
    public float countDownTimer = 6;
    
    static Menu gameOverMenu;
    static Menu escMenu;
    static Menu goalMenu;
    static Menu startButton;
    static Menu countDown;
    static Timer timer;

    [SerializeField] GameObject playerController;
    static Rigidbody rb;
    static CharacterLook character;

    public MenuActions menuControls;
    private InputAction pause;
    private InputAction click;

    bool startCountDown = false;

    
    private void Awake()
    {
        Instance = this;

        escMenu = transform.GetChild(0).GetComponent<Menu>();
        gameOverMenu = transform.GetChild(1).GetComponent<Menu>();
        goalMenu = transform.GetChild(2).GetComponent<Menu>();
        startButton = transform.GetChild(3).GetComponent<Menu>();
        timer = transform.GetChild(4).GetComponent<Timer>();
        countDown = transform.GetChild(5).GetComponent<Menu>(); 

        character = (CharacterLook)playerController.GetComponent("CharacterLook");
        rb = playerController.GetComponent<Rigidbody>();
        
        menuControls = new MenuActions();
        PauseGame();
        StartGame();
    }

    void FixedUpdate()
    {
        if(!startCountDown) return;
        
        CountDown();
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
        if (!escMenu.open && !gameOverMenu.open && !goalMenu.open && !startButton.open && !countDown.open) OpenEscMenu(); 
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
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void ResumeGame ()
    {
        UnFreezeCharacter();
        Time.timeScale = 1;
        Cursor.visible = false;
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
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(levelNumber+1);
    }

    public void LevelComplete()
    {
        PauseGame();
        goalMenu.Open();
    }

    public void OpenGameOverMenu()
    {
        FreezeCharacter();
        gameOverMenu.Open();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        countDown.Open();
        startCountDown = true;       
    }

    public void CountDown()
    {
        countDownTimer -= Time.fixedDeltaTime;

        if(countDownTimer > 1) 
        {
            countDownText.text = "" + (int)countDownTimer;
        }

        else if(countDownTimer <= 1)
        {
            startCountDown = false;
            countDown.Close();
            timer.gameStarted = true;
            timer.gameObject.SetActive(true);
            ResumeGame();
        }
    }

}
