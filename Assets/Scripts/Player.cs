using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action deathByFalling;
    public event Action deathByLava;

    CanvasManager canvasManager; 
    static Menu goalmenu;

    void Start()
    {
        canvasManager = GameObject.FindObjectOfType<CanvasManager>();
    }

    void Update()
    {
        
    }

    void Die()
    {
        if (deathByFalling != null)
            deathByFalling();

        if (deathByLava != null)
            deathByLava();

        //player death code here
    }


    //can use this logic for when falling into lava, "timer-death" is already complete
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeliPad") 
        {
            canvasManager.LevelComplete();
        }
        
        if(other.tag == "Lava")
        {
            canvasManager.OpenGameOverMenu();
        }
    }

}
