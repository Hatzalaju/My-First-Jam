using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float playerSpeed = 5f;
    
    //Variables Vida
    private int maxlife = 3;
    private int life = 3;
    public Image[] hearts;
    private int currentHearts;

    public TMP_Text playerPoints;
    public TMP_Text textButterflyPoints;
    private int sumPoints = 0;
    private int butterflyPoint = 0;

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

        if (collision.gameObject.CompareTag("ObjectPoint"))
                       
        {
            int[] possiblePoints = { 50, 100 };

            
            int randomPoints = possiblePoints[Random.Range(0, possiblePoints.Length)];
                        

            Destroy(collision.gameObject);

            if (sumPoints >= 0)
            {
                sumPoints += randomPoints;
            }

            playerPoints.text = sumPoints.ToString();

            Debug.Log(randomPoints);
        }

        if (collision.gameObject.CompareTag("Butterfly"))
        {
            Destroy(collision.gameObject);
            butterflyPoint = butterflyPoint + 1;
            sumPoints += 100;

            textButterflyPoints.text = butterflyPoint.ToString();
            playerPoints.text = sumPoints.ToString();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (butterflyPoint == 5 && collision.gameObject.CompareTag("SummerWall") )
        {
            Destroy(collision.gameObject);
        }
        if (butterflyPoint == 10 && collision.gameObject.CompareTag("FallWall"))
        {
            Destroy(collision.gameObject);
        }
        if (butterflyPoint == 15 && collision.gameObject.CompareTag("WinterWall"))
        {
            Destroy(collision.gameObject);
        }
        if (butterflyPoint == 20 && collision.gameObject.CompareTag("SpringWall"))
        {
            Destroy(collision.gameObject);
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