using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings settings;

    public bool lavaDisabled = false;
    public bool timerDisabled = false;
    
    Toggle lavaToggle;
    Toggle timerToggle;
    
    void Awake()
    {
       //if (settings == null)
       //{
       //    DontDestroyOnLoad(gameObject);
       //    settings = this;
       //}
//
       // else if (settings != this)
       // {
       //     Destroy(gameObject);
       // }
//
       // GameObject[] objs = GameObject.FindGameObjectsWithTag("Settings");

       // if (objs.Length > 1)
       // {
       //     Destroy(this.gameObject);
       // }
        
    }

    void FixedUpdate()
    {
    }

    public void LavaToggle(bool tog)
    {
        if(tog) 
        {
            Debug.Log("1");
            PlayerPrefs.SetInt("lavaDisabled", 1);
        }

        else 
        {
            Debug.Log("0");
            PlayerPrefs.SetInt("lavaDisabled", 0);
        }
        lavaDisabled = tog;
    }

    public void TimerToggle(bool tog)
    {
        if(tog) 
        {
            Debug.Log("1");
            PlayerPrefs.SetInt("timerDisabled", 1);
        }

        else 
        {
            Debug.Log("0");
            PlayerPrefs.SetInt("timerDisabled", 0);
        }
        
        timerDisabled = tog;
    }
}
