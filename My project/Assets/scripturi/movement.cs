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

    [Header("Movement")]
    public float Speed = 5f;
     public static int isfacingright;
      
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    { 
      
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

       

        


    }
      

     
}