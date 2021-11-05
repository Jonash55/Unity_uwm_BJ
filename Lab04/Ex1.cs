using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ex1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public List<Material> randomMaterials;
    public int numberOfObjects = 10;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        Vector3 boundsMax = GetComponent<MeshRenderer>().bounds.max;
        Vector3 boundsMin = GetComponent<MeshRenderer>().bounds.min;
        
        
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(Convert.ToInt32(boundsMin.x), Convert.ToInt32(boundsMax.x)).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));
        List<int> pozycje_z = new List<int>(Enumerable.Range(Convert.ToInt32(boundsMin.z), Convert.ToInt32(boundsMax.z)).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));

        for (int i = 0; i < numberOfObjects; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject newObject = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            newObject.GetComponent<MeshRenderer>().material = this.randomMaterials[UnityEngine.Random.Range(0, randomMaterials.Count)];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
