using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaMeter : MonoBehaviour
{
    public Image FillImage;

    public Slider slider;
    
    void Awake()
    {
        slider = GameObject.FindObjectOfType<Slider>();
        if (slider.tag == "SliderLava")
        {
            slider.value = GameObject.FindGameObjectWithTag("Lava").transform.position.y;
        }
        else if (slider.tag == "SliderPlayer")
        {
            slider.value = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(slider.tag == "SliderLava")
        {
            float fillValueLava = GameObject.FindGameObjectWithTag("Lava").transform.position.y;
            slider.value = fillValueLava;
        }
        else if(slider.tag == "SliderPlayer")
        {
            float fillValuePlayer = GameObject.FindGameObjectWithTag("Player").transform.position.y;
            slider.value = fillValuePlayer;
        }
        

    }
}
