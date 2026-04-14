using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;
    private PlayerInput playerInput;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
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
        anim.SetBool("Grounded", playerMovement.IsGrounded());
        anim.SetBool("Block", playerInput.IsBlocking && playerMovement.IsGrounded());
    }

    private void TriggerAttack()
    {
        anim.SetTrigger("Attack");
    }
}
