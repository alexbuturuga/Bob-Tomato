using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hp : MonoBehaviour
{
    [Header("sistem hp")]
    public int health;
    public int numofhearts;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;
    public Rigidbody2D rb;


    [Header("etc")]
    public float power;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (health > numofhearts)
            health = numofhearts;

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i<health)
            {
                hearts[i].sprite = fullheart;

            }
            else
            {
                hearts[i].sprite = emptyheart;
            }




            if(i<numofhearts)
            { hearts[i].enabled = true; }
            else { hearts[i].enabled = false; }
        }
    }




    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {
            health--;
            if (movement.isfacingright == 1)
                rb.AddForce(-transform.right * power);
            else
                rb.AddForce(transform.right * power);
            if(rb.velocity.y!=0)
                rb.AddForce(transform.up * power);
        }
    }
}
