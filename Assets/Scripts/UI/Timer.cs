using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] TMP_Text timeInt;
    [SerializeField] TMP_Text colon;
    

    public float timeLeft = 300;

    public bool gameStarted = false;

    public bool fellInLava = false;

    CanvasManager canvasManager; 
    Settings settings;

    void Start()
    {
        Instance = this;
        canvasManager = GameObject.FindObjectOfType<CanvasManager>();
        settings = GameObject.FindObjectOfType<Settings>();
    }

    void FixedUpdate()
    {
        if(!gameStarted || PlayerPrefs.GetInt("timerDisabled") == 1) 
        {
            gameObject.SetActive(false);
            return;
        }

        if(fellInLava)
        {
            timeLeft = Time.fixedDeltaTime; 
            return;
        }
        else timeLeft -= Time.fixedDeltaTime;

        gameObject.SetActive(true);

        timeInt.text = ShowTimer();

    }

    public void SetTimer(float time)
    {
        this.timeLeft = time;
    }

    public string ShowTimer()
    {
        string timerText = null;

        if(timeLeft > 0) //tid kvar
        {
            timeLeft -= Time.fixedDeltaTime; //minska tid

            if(timeLeft > 60 ) 
            {
                timerText = "0" + (int)timeLeft / 60 +"  "+ (int)timeLeft % 60;

                if(timeLeft % 60 < 10 ) 
                {
                    timerText = "0" + (int)timeLeft / 60 +"  0"+(int)timeLeft % 60;
                }
            }

            if(timeLeft < 60 ) // 00:xx
            {
                timeInt.color = Color.red;
                colon.color = Color.red;

                timerText = "00  " + (int)timeLeft;

                if(timeLeft < 10) timerText = "00  0" + (int)timeLeft;             
            }      
        }

        else
        {
            canvasManager.OpenGameOverMenu();           
        }
        return timerText;
    }
}
