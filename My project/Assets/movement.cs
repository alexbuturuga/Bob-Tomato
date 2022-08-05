using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movement : MonoBehaviour
{
    public float Speed = 5f;
    public bool isGrounded;
    private bool isjumping;
    public Rigidbody2D rb;
    public float jumpforce;
    private float jumptime;
    public float jumpstarttime;
    public float gravityIncreasePerSecond = 0.8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isGrounded)
            rb.gravityScale += gravityIncreasePerSecond * Time.deltaTime;
        else rb.gravityScale = 1;
        if (!isjumping)
        { jumptime = -1; }
        if (isGrounded == true && Input.GetButtonDown("Jump")) //cand se apasa space
        {
            isjumping = true;
            jumptime = jumpstarttime;
            rb.velocity = Vector2.up * jumpforce;
        }
        if (Input.GetButton("Jump") && isjumping == true) //cat timp e space apasat
        {
            if (jumptime > 0)
            {
                rb.velocity = Vector2.up * jumpforce;
                jumptime -= Time.deltaTime;
            }
            else
            {
                isjumping = false;

            }

        }
        if (Input.GetKeyUp(KeyCode.Space)) //cand nu se mai apasa space
            {
                isjumping = false;
            }


        }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * Speed, rb.velocity.y); //miscare stanga-dreapta
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Map"))
        { isGrounded = true; }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Map"))
        { isGrounded = true; }
    }

    void OnCollisionExit2D(Collision2D col)
    { isGrounded = false; }
}