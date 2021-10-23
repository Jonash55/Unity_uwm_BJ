using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEx5 : MonoBehaviour
{

    public GameObject prefab;
    public int numberOfObjects = 20;
    List<Vector3> listaWykorzystanych = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        bool isGood_x;
        bool isGood_z;
        for (int i = 0; i < 10; i++)
        {
            prefab.transform.position = new Vector3(15, 0, 5);
            isGood_x = true;
            isGood_z = true;
            Vector3 vec = new Vector3(Random.Range(0.5f, 9.5f), 0.5f, Random.Range(0.5f, 9.5f));
            if (i == 0)
            {
                listaWykorzystanych.Add(vec);
                Instantiate(prefab, transform.position + vec, Quaternion.identity);
            }
            else
            {
                foreach (var vector in listaWykorzystanych)
                {
                    if ((vector.x - 0.5) <= vec.x && vec.x <= (vector.x + 0.5))
                    {
                        isGood_x = false;
                        continue;
                    }
                    if ((vector.z - 0.5) <= vec.z && vec.z <= (vector.z + 0.5))
                    {
                        isGood_z = false;
                        continue;
                    }
                }
                if (isGood_x && isGood_z)
                {
                    listaWykorzystanych.Add(vec);
                    Instantiate(prefab, transform.position + vec, Quaternion.identity);
                }
                else
                {
                    i -= 1;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
