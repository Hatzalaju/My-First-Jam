using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyPatrol : MonoBehaviour
{
    private float speed = 5f;
    private float waitTime;
    private float startWaitTime = 0.1f;

    public Transform moveSpot;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;


    private void Start()
    {
        waitTime = startWaitTime;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
