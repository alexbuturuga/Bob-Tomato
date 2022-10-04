using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
 public Transform player;
     private Rigidbody2D rb;
     private Vector2 movement;
     public float moveSpeed = 3f;
     public float limit = 8f;
     public bool agro = false;


     // Start is called before the first frame update
     void Start()
     {
         rb = this.GetComponent<Rigidbody2D>();

     }

     // Update is called once per frame
     void Update()
     {Vector3 direction = player.position - transform.position;


         //Inamicul se va roti in functie de pozitia caracterului
         //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         //rb.rotation = angle;
         direction.Normalize();
         movement = direction; 
         //Debug.Log(Mathf.Abs(transform.position.x - player.position.x));
        // Debug.Log(limit);
        /* if((transform.position.x - player.position.x) <= limit)
         agro = true;
         else
         agro = false;*/
     }
     void FixedUpdate()
     { 
       
         MoveCharacter(movement);
     }
     void MoveCharacter(Vector2 direction)
     {
         
         rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
          Vector2 v2 = new Vector2(transform.position.x + (direction.x * moveSpeed * Time.deltaTime), transform.position.y);
          rb.MovePosition(v2);


         

     }
    /*
public float attackSpeed = 4;
public GameObject player;

Transform playerTransform;

void GetPlayerTransform()
{
    if (player != null)
    {
        playerTransform = player.transform;
    }
    else
    {
        Debug.Log("Player not specified in Inspector");
    }
}

// Start is called before the first frame update
void Start()
{
    GetPlayerTransform();
}

// Update is called once per frame
void Update()
{

            transform.position += transform.forward * attackSpeed * Time.deltaTime;


}
*/
}
