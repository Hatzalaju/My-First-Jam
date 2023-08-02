using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float playerSpeed = 5f;
    
    //Variables Vida
    private int maxlife = 3;
    private int life = 3;
    public Image[] hearts;
    private int currentHearts;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        currentHearts = hearts.Length;
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

        SystemPlayerLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Misil"))
        {
            Destroy(collision.gameObject);
            LoseHeart();
        }
    }


    private void SystemPlayerLife()
    {
        if (life <= 0)
        {
            Debug.Log("Murio");
        }
    }

    public void LoseHeart()
    {
        if (currentHearts > 0)
        {
            // Desactivamos la imagen del corazón actual.
            hearts[currentHearts - 1].gameObject.SetActive(false);
            currentHearts--;
            life--;
        }
    }
}