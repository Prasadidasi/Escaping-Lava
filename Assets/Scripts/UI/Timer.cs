using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] TMP_Text timeInt;
    [SerializeField] TMP_Text colon;
    

    private float timeLeft  = 180;
    private float normal    = 180; //3.00
    private float medium    = 150; //2.30
    private float hard      = 90;  //1.30

    public bool gameStarted = false;

    public bool fellInLava = false;

    static Vector3 startPos;

    CanvasManager canvasManager;

    void Start()
    {
        Instance = this;
        canvasManager = GameObject.FindObjectOfType<CanvasManager>();
        startPos = transform.localPosition;
        timerDiff();
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

        gameObject.SetActive(true);

        timeInt.text = ShowTimer();

    }

    public void SetTimer(float time)
    {
        this.timeLeft = time;
    }

    public void timerDiff()
    {
        if(PlayerPrefs.GetInt("Normal") == 1)
        {
            timeLeft = normal;
        }
        
        else if (PlayerPrefs.GetInt("Medium") == 1)
        {
            timeLeft = medium;
        }

        else if (PlayerPrefs.GetInt("Hard") == 1)
        {
            timeLeft = hard;
        }
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

            if(timeLeft <= 10)
            {
                transform.localPosition = new Vector3(0f, startPos.y - 275f, 0f);
                transform.localScale = new Vector3(2, 2, 1);
            }
        }

        else
        {
            canvasManager.OpenGameOverMenu();           
        }
        return timerText;
    }
}
