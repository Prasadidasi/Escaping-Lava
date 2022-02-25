using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vignette : MonoBehaviour
{
    private static Vignette Instance;

    void Start()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = GameObject.FindGameObjectWithTag("Player").transform.position.y - GameObject.FindGameObjectWithTag("Lava").transform.position.y;
        
        if ( distance < 7 )
        {
            GameObject.FindGameObjectWithTag("Vignette").SetActive(true);
        }

    }
}
