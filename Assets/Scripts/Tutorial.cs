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
    public bool completeTrigger = false;

    bool flag = true;

    float timer;
    static Vector3 startPos;
    static Quaternion quat = new Quaternion(0, 0, 0, 0);

    void Awake()
    {
        startPos = gauntletTimer.transform.localPosition;
        Instance = this;          
    }


    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if(timer > 3) 
        {
            gauntletTimer.transform.localPosition = new Vector3(0f, startPos.y+5000f, 0f);
            welcome.SetActive(true);
        }

        if (timer >= 8) 
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
            gauntletTimer.transform.localPosition = startPos;
            
            if(flag) 
            {
                gauntletTimer.GetComponent<Timer>().SetTimer(60f);
                flag = false;
            }
        }

        if(completeTrigger)
        {
            gauntletTimer.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

}
