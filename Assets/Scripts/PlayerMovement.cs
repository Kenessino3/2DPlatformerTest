using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;
    public float speed;

    //Called everytime the script is loaded
    //Grabs references for the Rigidbody component to body and animator to anim
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    //checking for input from the player
    void Update()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
       body.linearVelocity = new Vector2(horizontalInput * speed,body.linearVelocity.y);

       // flip player depending on the direction they are moving
       if (horizontalInput > 0.01f)
       {
           transform.localScale = new Vector3(3, 3, 3);
       }
       else if (horizontalInput < -0.01f)
       {
           transform.localScale = new Vector3(-3, 3, 3);
       }
       
       if (Input.GetKey(KeyCode.Space) && Grounded)
       {
           Jump();
       }
       
       //set animator parameters
       anim.SetBool("Run", horizontalInput != 0);
       anim.SetBool("Grounded", Grounded);
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x,speed);
        anim.SetTrigger("Jump");
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}
