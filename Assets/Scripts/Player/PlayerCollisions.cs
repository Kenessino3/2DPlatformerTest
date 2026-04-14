using System;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [Header("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    
    //from Movement and Animator
    public bool IsGrounded { get; private set; }
    public bool IsTouchingWall { get; private set; }

    //pass transform for respawn script
    public static event Action<Transform> OnCheckpointReached;

    private void Update()
    {
        CheckEnvironment();
    }

    private void CheckEnvironment()
    {
        //ground check
        RaycastHit2D groundHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        IsGrounded = groundHit.collider != null;
        
        //wall check
        RaycastHit2D wallHit =Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        IsTouchingWall = wallHit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            //broadcast that a checkpoint was reached and sent the transform
            OnCheckpointReached?.Invoke(collision.transform);
            
            collision.GetComponent<Collider2D>().enabled = false; //Deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("Appear"); //Trigger checkpoint animation
        }
    }
}
