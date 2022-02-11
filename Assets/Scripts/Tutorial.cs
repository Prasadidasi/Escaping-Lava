using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance;

    [SerializeField] GameObject welcome;
    [SerializeField] GameObject walk;
    [SerializeField] GameObject jump;
    [SerializeField] GameObject sprint;
    [SerializeField] GameObject longJump;
    [SerializeField] GameObject gauntlet;
    [SerializeField] GameObject gauntletTimer;

    public bool jumpTrigger = false;
    public bool sprintTrigger = false;
    public bool longJumpTrigger = false;
    public bool gauntletTrigger = false;

    float timer;

    void Awake()
    {
        Instance = this;          
    }


    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if(timer > 3) welcome.SetActive(true);
        if(timer >= 8) 
        {
            welcome.SetActive(false);
            walk.SetActive(true);
        }

        if(jumpTrigger) 
        {
            welcome.SetActive(false);
            walk.SetActive(false);
            jump.SetActive(true);
        }

        if(sprintTrigger) 
        {
            jump.SetActive(false);
            sprint.SetActive(true);
        }
        
        if(longJumpTrigger) 
        {
            sprint.SetActive(false);
            longJump.SetActive(true);
        }

        if(gauntletTrigger) 
        {            
            longJump.SetActive(false);
            gauntlet.SetActive(true);
            gauntletTimer.SetActive(true);
            RectTransform rTrans = gauntletTimer.GetComponent<RectTransform>();
            //rTrans.position = new Rect(0f, -275f, 0);
        }
    }

}
