using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    public static Launcher Instance;

    [SerializeField] Menu titleMenu;
    [SerializeField] Toggle lavaToggle;
    [SerializeField] Toggle timerToggle;

    //List<int> spawnPointList;

    void Awake()
    {
        Instance = this;
        MenuManager.Instance.OpenMenu("loading");
    }

    void Start()
    {
        MenuManager.Instance.OpenMenu(titleMenu);
    }

    void Update()
    {
    }    

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        if(PlayerPrefs.GetInt("lavaDisabled") == 1)
        {
            lavaToggle.isOn = true;
        }

        if(PlayerPrefs.GetInt("timerDisabled") == 1)
        {
            timerToggle.isOn = true;
        }
    }
}

