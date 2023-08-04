using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilPrefab : MonoBehaviour
{

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
