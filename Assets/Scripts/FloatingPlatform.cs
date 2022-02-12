using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class FloatingPlatform : MonoBehaviour
{    
    private Rigidbody rigidBody;
    private bool isTouchingLava = false;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.mass = 100;
        rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        if (isTouchingLava)
        {
            Debug.Log("It Burns but it floats");
            rigidBody.AddForce(transform.up * rigidBody.mass);
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
            rigidBody.velocity = Vector3.zero;
        }
    }
}
