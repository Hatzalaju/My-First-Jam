using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public float spawnTimeInterval = 4.5f; 
    public float Speed = 5.0f;

    private void Awake()
    {
        
    }

    void Start()
    {
        InvokeRepeating("SpawnObject", 0.0f, spawnTimeInterval);
    }

    void SpawnObject()
    {
        GameObject objectPrefab = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        objectPrefab.GetComponent<Rigidbody2D>().velocity = Vector2.left * Speed;
    }
}