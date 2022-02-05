using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    public static Launcher Instance;

    [SerializeField] Menu titleMenu;


    //List<int> spawnPointList;

    void Awake()
    {
        Instance = this;
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

    

}

