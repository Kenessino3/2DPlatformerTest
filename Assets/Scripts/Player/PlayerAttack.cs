using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    
    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header("Layers")]
    [SerializeField] private LayerMask attackableLayer;
    
    [Header("Sound Parameters")]
    [SerializeField] private AudioClip swordhitsound;
    
    //events
    public static event Action OnAttackStarted;
    public static event Action OnAttackEnded;
    
    //Refs
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    //subscribe
    private void OnEnable()
    {
        PlayerInput.OnAttackPressed += AttemptAttack;
    }
    //unsubscribe
    private void OnDisable()
    {
        PlayerInput.OnAttackPressed -= AttemptAttack;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    private void AttemptAttack()
    {
        if (cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            cooldownTimer = 0;
                   
            //lock movement
            OnAttackStarted?.Invoke(); 
        }
        
    }

    public void UnlockMovement()
    {
        OnAttackEnded?.Invoke();
    }
    
    private void DamageEnemy()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0f,
            Vector2.zero,
            0f,
            attackableLayer
        );

        if (hit.collider != null)
        {
            SoundManager.instance.PlaySound(swordhitsound);
            
            //Check if enemy
            Health enemyHealth = hit.collider.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            //Check if destructible object
            DestructibleObject destructibleObject = hit.collider.GetComponent<DestructibleObject>();
            if (destructibleObject != null)
            {
                destructibleObject.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (boxCollider == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        );
    }
}
