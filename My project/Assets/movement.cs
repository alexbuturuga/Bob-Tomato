 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movement : MonoBehaviour
{
    [Header("Referinte Obiecte")]
    public Transform groundcheck;
    public Transform frontcheck;
    public LayerMask groundlayer;
    public Rigidbody2D rb;

    [Header("Jump")]
    public float Speed = 5f;
    public bool isGrounded;
    private bool isjumping;
    public float jumpforce;
    private float jumptime;
    public float jumpstarttime;
    public float gravityIncreasePerSecond = 0.8f;

    [Header("Wall Slide")]
    public bool istouchingfront;
    public bool wallsliding;
    public float wallslidingspeed;
    public float checkradius;
    public bool walljumping;
    public float walljumptime;
    public float xWallforce;
    public float yWallforce;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isGrounded && !wallsliding)
            rb.gravityScale += gravityIncreasePerSecond * Time.deltaTime;
        else rb.gravityScale = 1;
        if (!isjumping)
        { jumptime = -1; }
        if ((isGrounded || wallsliding) && Input.GetButtonDown("Jump")) //cand se apasa space
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
        bool isfacingright;
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0)
        {
            isfacingright = false;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else
        {
            isfacingright = true;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        rb.velocity = new Vector2(h * Speed, rb.velocity.y); //miscare stanga-dreapta

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, groundlayer);

        //wall slide



        istouchingfront = Physics2D.OverlapCircle(frontcheck.position, checkradius, groundlayer);


        if (istouchingfront && !isGrounded)
        { wallsliding = true; }
        else { wallsliding = false; }

        if (wallsliding)
        { rb.velocity = new Vector2(rb.velocity.x, -Mathf.Clamp(rb.velocity.y, wallslidingspeed, float.MaxValue)); }

        if (Input.GetButton("Jump") && wallsliding  )
        {
            walljumping = true;
            Invoke("SetWallJumpingToFalse", walljumptime);
        }

        if (walljumping)
        { 
            rb.velocity = new Vector2(xWallforce * -h, yWallforce); }
      



    }
    void SetWallJumpingToFalse()
    {
        walljumping = false;
    }


}
