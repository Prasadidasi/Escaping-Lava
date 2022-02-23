using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CanvasManager canvasManager; 
    static Menu goalmenu;
    private Rigidbody rb;

    void Start()
    {
        canvasManager = GameObject.FindObjectOfType<CanvasManager>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeliPad") 
        {
            canvasManager.LevelComplete();
        }
        
        if(other.tag == "Lava")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Lava");
            Lava lava = (Lava)obj.GetComponent("Lava");
            lava.isLavaRising = false;

            Timer timer = canvasManager.transform.GetChild(4).GetComponent<Timer>();
            timer.fellInLava = true;

            canvasManager.OpenGameOverMenu();

        }

    }

}
