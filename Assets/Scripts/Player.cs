using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action deathByFalling;
    public event Action deathByLava;

    CanvasManager canvasManager;

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
