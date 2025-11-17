using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    //Called everytime the script is loaded
    //Grabs references for the Rigidbody component to body and animator to anim
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    //checking for input from the player
    void Update()
    { 
        horizontalInput = Input.GetAxis("Horizontal");

       // flip player depending on the direction they are moving
       if (horizontalInput > 0.01f)
       {
           transform.localScale = new Vector3(3, 3, 3);
       }
       else if (horizontalInput < -0.01f)
       {
           transform.localScale = new Vector3(-3, 3, 3);
       }

       //wall jump logic
       if (wallJumpCooldown > 0.2f)
       {
           body.linearVelocity = new Vector2(horizontalInput * speed,body.linearVelocity.y);

           if (onWall() && !isGrounded())
           {
               body.gravityScale = 0;
               body.linearVelocity = Vector2.zero;
           }
           else
           {
               body.gravityScale = 7.0f;
           }
           if (Input.GetKey(KeyCode.Space))
           {
               Jump();
           }
       }
       else
       {
           wallJumpCooldown += Time.deltaTime;
       }
       
       //set animator parameters
       anim.SetBool("Run", horizontalInput != 0);
       anim.SetBool("Grounded", isGrounded());
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x,jumpPower);
            anim.SetTrigger("Jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCooldown = 0;
        }
        
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,
            0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0),
            0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
    
}
