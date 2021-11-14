using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex3 : MonoBehaviour
{
    public List<GameObject> positions = new List<GameObject>();
    int current = 0;
    bool isRunning;
    bool isRunningForward;
    bool isRunningBackward;
    public float speed;
    float WPradius = 1;

    void Start()
    {
        GameObject start = new GameObject();
        start.transform.position = this.gameObject.transform.position;
        positions.Insert(0, start);
        isRunning = false;
        isRunningForward = true;
        isRunningBackward = false;
    }

    void Update()
    {
        if(isRunning)
        {
            if (Vector3.Distance(positions[current].transform.position, transform.position) < WPradius)
            {
                if (isRunningForward)
                    current++;

                if (isRunningBackward)
                    current--;

                if (current == positions.Count)
                {
                    isRunningForward = false;
                    isRunningBackward = true;
                    current--;
                }

                if (current == 0)
                {
                    isRunningForward = true;
                    isRunningBackward = false;
                }
                    
            }
            transform.position = Vector3.MoveTowards(transform.position, positions[current].transform.position, Time.deltaTime * speed);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
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
