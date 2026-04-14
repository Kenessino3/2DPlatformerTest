using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAudio : MonoBehaviour
{
    [Header("Audio Components")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip checkpointSound;

    private void OnEnable()
    {
        PlayerAttack.OnAttackStarted += PlayAttackSound;
        PlayerInput.OnJumpPressed += PlayJumpSound;
        PlayerCollisions.OnCheckpointReached += PlayCheckpointSound;
    }
    
    private void OnDisable()
    {
        PlayerAttack.OnAttackStarted -= PlayAttackSound;
        PlayerInput.OnJumpPressed -= PlayJumpSound;
        PlayerCollisions.OnCheckpointReached -= PlayCheckpointSound;
    }

    private void PlayAttackSound()
    {
        if (attackSound != null)
        {
            SoundManager.instance.PlaySound(attackSound);
        }
    }
    private void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            SoundManager.instance.PlaySound(jumpSound);
        }
    }
    
    private void PlayCheckpointSound(Transform checkpointTransform)
    {
        if (checkpointSound != null)
        {
            SoundManager.instance.PlaySound(checkpointSound);
        }
    }
}
