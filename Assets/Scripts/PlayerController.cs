using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movementHorizontal = Input.GetAxisRaw("Horizontal");
        float movementVertical = Input.GetAxisRaw("Vertical");

        // Solo permitimos el movimiento en una dirección a la vez
        if (movementHorizontal != 0 && movementVertical != 0)
        {
            if (Mathf.Abs(movementHorizontal) > Mathf.Abs(movementVertical))
            {
                movementVertical = 0f;
            }
            else
            {

                movementHorizontal = 0f;
            }

        }

        Vector2 movement = new Vector2(movementHorizontal, movementVertical).normalized;

        rb.velocity = movement * playerSpeed;
    }



}