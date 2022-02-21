using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float speed = 0.0005f;
    public bool isLavaRising = true;

    Settings settings;

    // Start is called before the first frame update
    void Awake()
    {
        settings = GameObject.FindObjectOfType<Settings>();
        //mask = LayerMask.NameToLayer("Platform"); 
    } 

    void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("lavaDisabled") == 1) isLavaRising = false;

        if (isLavaRising)
        {
            transform.Translate(Vector3.up * speed, Space.World);
        }
    }
}
