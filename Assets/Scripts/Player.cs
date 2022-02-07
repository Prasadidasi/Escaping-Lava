using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action deathByFalling;
    public event Action deathByLava;
    void Start()
    {
        
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
}
