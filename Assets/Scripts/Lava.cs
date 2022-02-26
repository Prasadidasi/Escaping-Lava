using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float speed;
    public bool isLavaRising = true;

    static float normal = 0.0015f;
    static float medium = 0.0028f;
    static float hard = 0.005f;

    Settings settings;

    void Awake()
    {
        //mask = LayerMask.NameToLayer("Platform"); 
        //speed = normal;
        SetSpeed();
    } 

    void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("lavaDisabled") == 1) isLavaRising = false;

        if (isLavaRising)
        {
            transform.Translate(Vector3.up * speed, Space.World);
        }
    }

    public void SetSpeed()
    {
        speed = normal;

        if(PlayerPrefs.GetInt("Normal") == 1)
        {
            speed = normal;
           // Debug.Log("normal speed: " + speed);
        }
        
        else if (PlayerPrefs.GetInt("Medium") == 1)
        {
            speed = medium;
            //Debug.Log("medium speed: " + speed);
        }

        else if (PlayerPrefs.GetInt("Hard") == 1)
        {
            speed = hard;
            //Debug.Log("hard speed: " + speed);
        }

        
    }
}
