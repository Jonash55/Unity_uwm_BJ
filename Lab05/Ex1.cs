using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex1 : MonoBehaviour
{

    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 12.6f;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private float forwardPosition;
    private float backwardPosition;

    void Start()
    {
        forwardPosition = transform.position.z + distance;
        backwardPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningForward && transform.position.z >= forwardPosition)
        {
            isRunning = false;
        }
        else if (isRunningBackward && transform.position.z <= backwardPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
        if (transform.position.z >= forwardPosition)
        {
            isRunningBackward = true;
            isRunningForward = false;
            elevatorSpeed = -elevatorSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            if (transform.position.z <= backwardPosition)
            {
                isRunningForward = true;
                isRunningBackward = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
        }
    }
}