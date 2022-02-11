using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    [SerializeField] Tutorial tutorial;
    [SerializeField] string trigger;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(trigger == "JumpTrigger")
            {
                tutorial.jumpTrigger = true;
                return;
            }

            if(trigger == "SprintTrigger")
            {
                tutorial.sprintTrigger = true;
                return;
            }
            
            if(trigger == "LongJumpTrigger")
            {
                tutorial.longJumpTrigger = true;
                return;
            }

            if(trigger == "GauntletTrigger")
            {
                tutorial.gauntletTrigger = true;
                return;
            }
                
                   
        }
    }
}
