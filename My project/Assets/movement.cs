 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movement : MonoBehaviour
{
<<<<<<< Updated upstream
    [Header("Referinte Obiecte")]
    public Transform groundcheck;
    public Transform frontcheck;
    public LayerMask groundlayer;
    public Rigidbody2D rb;

    [Header("Jump")]
=======
    private float h;
>>>>>>> Stashed changes
    public float Speed = 5f;
    public bool isGrounded;
    private bool isjumping;
    public float jumpforce;
    private float jumptime;
    public float jumpstarttime;
    public float gravityIncreasePerSecond = 0.8f;

<<<<<<< Updated upstream
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
=======
    private bool isDashing = false;
    private bool canDash = true;
    private float dashingPower = 12f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private bool isFacingRight = true;


>>>>>>> Stashed changes
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
<<<<<<< Updated upstream
        if (!isGrounded && !wallsliding)
=======
        if(isDashing) //cat timp caracterul e in dash nu poate face nimic altceva
        {
            return;
        }
        if (!isGrounded)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        {
            isjumping = false;
            
        }



        if (isGrounded)
        { wallsliding = false; }

=======
            {
                isjumping = false;
            }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) //cand se apasa shift si caracterul nu este in dash
        {
            StartCoroutine(dash());
        }
        Flip();//apeleaza functie flip pt a intoarce caracterul daca e nevoie
>>>>>>> Stashed changes


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
<<<<<<< Updated upstream
  
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
=======
        if(isDashing) //cat timp caracterul e in dash nu poate face nimic altceva
        {
            return;
        }
        h = Input.GetAxisRaw("Horizontal");
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream

}
=======
    void OnCollisionExit2D(Collision2D col)
    { isGrounded = false; }

    private IEnumerator dash() //cod pt dash
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void Flip() //intoarce caracterul in functie de directia in care mergi
    {
        if(isFacingRight && h < 0f || !isFacingRight && h > 0f) 
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
>>>>>>> Stashed changes
