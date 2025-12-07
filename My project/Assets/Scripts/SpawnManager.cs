using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float minTime = 1f;
    public float maxTime = 2f;

    void Start()
    {
        StartCoroutine(SpawnCoRutine(0));
    }

    IEnumerator SpawnCoRutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length-1)], transform.position, Quaternion.identity);
        StartCoroutine(SpawnCoRutine(Random.Range(minTime, maxTime)));
    }
    void Update()
    {
        
    }
}
