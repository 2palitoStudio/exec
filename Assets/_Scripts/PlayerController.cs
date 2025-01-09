using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

     private Rigidbody2D rb;
     private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Captura teclas (A/D ou setas)
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Adiciona força para cima
            isGrounded = false; // Define que não está no chão
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Está no chão ainda bem eim
        }
         if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy!");

            
            Destroy(collision.gameObject); 
        }
    }
 
}
