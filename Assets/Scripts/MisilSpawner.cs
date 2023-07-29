using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public float spawnInterval = 4.5f; 
    public float movementSpeed = 5.0f; 

    void Start()
    {
        InvokeRepeating("SpawnObject", 0.0f, spawnInterval);
    }

    void SpawnObject()
    {
        GameObject newObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        newObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * movementSpeed;
    }
}