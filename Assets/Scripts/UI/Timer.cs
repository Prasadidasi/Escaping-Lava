using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] TMP_Text timeInt;

    public float timeLeft = 300;

    public bool gameStarted = false;

    CanvasManager canvasManager; 

    void Start()
    {
        Instance = this;
        canvasManager = GameObject.FindObjectOfType<CanvasManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!gameStarted) return;

        gameObject.SetActive(true);

        if(timeLeft > 0) 
        {
            timeLeft -= Time.fixedDeltaTime;

            if(timeLeft < 60 ) 
            {
                timeInt.color = Color.red;
                timeInt.text = "00" + (int)timeLeft / 60 + ":" + (int)timeLeft % 60;

                if(timeLeft < 60 && timeLeft % 60 < 10) timeInt.text = "00" + (int)timeLeft / 60 + ":0" + (int)timeLeft % 60;
                return;
            }

            if(timeLeft % 60 < 10) timeInt.text = "" + (int)timeLeft / 60 + ":0" + (int)timeLeft % 60;

            else timeInt.text = "0" + (int)timeLeft / 60 + ":" + (int)timeLeft % 60;
            return;
        }

        if(timeLeft <= 0)
        {
            canvasManager.OpenGameOverMenu();
        }
        


    }
}
