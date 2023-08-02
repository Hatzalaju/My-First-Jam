using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilPrefab : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pego");
        }
    }*/

    private void Update()
    {

        StartCoroutine(DestrucionMisil());


    }


    IEnumerator DestrucionMisil()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
