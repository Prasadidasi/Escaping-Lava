using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private float speed;
    public bool isLavaRising = true;

    static float normal = 0.00005f;
    static float medium = 0.0005f;
    static float hard = 0.005f;

    Settings settings;

    // Start is called before the first frame update
    void Awake()
    {
        //mask = LayerMask.NameToLayer("Platform"); 
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
        if(PlayerPrefs.GetInt("Normal") == 1)
        {
            speed = normal;
            Debug.Log(speed);
        }
        
        else if (PlayerPrefs.GetInt("Medium") == 1)
        {
            speed = medium;
            Debug.Log(speed);
        }

        else if (PlayerPrefs.GetInt("Hard") == 1)
        {
            speed = hard;
            Debug.Log(speed);
        }
    }
}
