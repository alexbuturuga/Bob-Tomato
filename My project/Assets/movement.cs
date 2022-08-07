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
    public bool space;
    public int isfacingright;
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
        if (isGrounded && Input.GetButtonDown("Jump")) //cand se apasa space
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



        if (isGrounded)
        { wallsliding = false; }



        if (Input.GetButtonDown("Jump"))
            space = true;
        else space = false;


        if (space && wallsliding)
        {
            walljumping = true;
            Invoke("SetWallJumpingToFalse", walljumptime);
        }


        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, groundlayer);
        istouchingfront = Physics2D.OverlapCircle(frontcheck.position, checkradius, groundlayer);

    

    }


    void FixedUpdate()
    {
  
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0)
        {
          isfacingright=-1;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(h>0)
        {
         isfacingright =1;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        rb.velocity = new Vector2(h * Speed, rb.velocity.y); //miscare stanga-dreapta

        //wall slide





            if (istouchingfront && !isGrounded)
        { wallsliding = true; }
        else { wallsliding = false; }
        if (istouchingfront && h == 0)
            wallsliding = true;
        if (wallsliding)
        { rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, h, float.MaxValue), -Mathf.Clamp(rb.velocity.y, wallslidingspeed, float.MaxValue)); }



        if (walljumping)
        {
            rb.velocity = new Vector2(xWallforce * -isfacingright, yWallforce);

        }




    }

    void SetWallJumpingToFalse()
    {
        walljumping = false;
    }


}
