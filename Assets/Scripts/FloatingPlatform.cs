using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float speed = 2f;
    
    private Rigidbody rigidBody;
    private bool isTouchingLava = false;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isTouchingLava)
        {
            Debug.Log("It Burns but it floats");
            rigidBody.AddForce(transform.up * speed);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lava")
        {
            isTouchingLava = true;
            rigidBody.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Lava")
        {
            isTouchingLava = false;
        }
    }
}
