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

        if(timeLeft > 0) //tid kvar
        {
            timeLeft -= Time.fixedDeltaTime; //minska tid

            if(timeLeft > 60 ) 
            {
                timeInt.text = "0" + (int)timeLeft / 60 +"  "+ (int)timeLeft % 60;

                if(timeLeft % 60 < 10 ) timeInt.text = "0" + (int)timeLeft / 60 +"  0"+(int)timeLeft % 60;

                return;
            }

            if(timeLeft < 60 ) // 00:xx
            {
                timeInt.color = Color.red;
                colon.color = Color.red;

                timeInt.text = "00  " + (int)timeLeft;

                if(timeLeft < 10) timeInt.text = "00  0" + (int)timeLeft;
                
                return;
            }

            
        }

        if(timeLeft <= 0)
        {
            canvasManager.OpenGameOverMenu();
        }

    }
}
