using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float speed = 0.0005f;
    public bool isLavaRising = true;

    // Start is called before the first frame update
    void Start()
    {
        //mask = LayerMask.NameToLayer("Platform"); 
    } 

    void FixedUpdate()
    {
        if (isLavaRising)
        {
            transform.Translate(Vector3.up * speed, Space.World);
        }
    }
}
