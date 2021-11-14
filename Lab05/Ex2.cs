using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2 : MonoBehaviour
{
    public float otwarcie = 2f;
    float zamkniecie;
    public float predkoscOtwierania = 1f;
    bool graczBlisko;

    // Start is called before the first frame update
    void Start()
    {
        graczBlisko = false;
        otwarcie += transform.position.x;
        zamkniecie = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(graczBlisko)
        {
            if(transform.position.x < otwarcie)
            {
                transform.Translate(predkoscOtwierania * Time.deltaTime, 0f, 0f);
            }
        }
        else
        {
            if(transform.position.x > zamkniecie)
            {
                transform.Translate(-predkoscOtwierania * Time.deltaTime, 0f, 0f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            graczBlisko = true;
            Debug.Log("Kolizja gracza");
        }
    }
}
