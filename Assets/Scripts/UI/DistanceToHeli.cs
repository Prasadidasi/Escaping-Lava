using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DistanceToHeli : MonoBehaviour
{
    public static DistanceToHeli Instance;
    [SerializeField] TMP_Text distance;
    private float speed;
    private float distanceUnit = 0f;
    private float xHeli = 0f;
    private float yHeli = 0f;
    private float xPlayer = 0f;
    private float yPlayer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InvokeRepeating("DistanceTravelled", 0, 1/speed);
    }

    // Update is called once per frame
    void Update()
    {
        DistanceTravelled();
        distance.text = "Distance to helicopter: " + distanceUnit.ToString("F1") + " m.";
        Debug.Log("Distance: " + distanceUnit);
    }

    void DistanceTravelled()
    {
        xHeli = GameObject.FindGameObjectWithTag("HeliPad").transform.position.x;
        yHeli = GameObject.FindGameObjectWithTag("HeliPad").transform.position.y;

        xPlayer = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        yPlayer = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        //distanceUnit = Mathf.Sqrt((Mathf.Pow(xHeli - xPlayer,2) + Mathf.Pow(yHeli - yPlayer,2)));
        distanceUnit = Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.z - GameObject.FindGameObjectWithTag("HeliPad").transform.position.z);

        
    }


}
