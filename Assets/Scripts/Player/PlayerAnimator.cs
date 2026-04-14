using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;
    private PlayerInput playerInput;
    private PlayerCollisions playerCollisions;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerCollisions = GetComponent<PlayerCollisions>();
    }

    private void OnEnable()
    {
        PlayerAttack.OnAttackStarted += TriggerAttack;
    }

    private void OnDisable()
    {
        PlayerAttack.OnAttackStarted -= TriggerAttack;
    }

    private void Update()
    {
        anim.SetBool("Run", playerMovement.IsRunning);
        anim.SetBool("Grounded", playerCollisions.IsGrounded);
        anim.SetBool("Block", playerInput.IsBlocking && playerCollisions.IsGrounded);
    }

    private void TriggerAttack()
    {
        anim.SetTrigger("Attack");
    }
}
