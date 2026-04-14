using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput {get; private set;}
    public bool IsBlocking {get; private set;}

    public static event Action OnJumpPressed;
    public static event Action OnJumpReleased;
    public static event Action OnAttackPressed;

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        IsBlocking = Input.GetMouseButton(1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpPressed?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnJumpReleased?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnAttackPressed?.Invoke();
        }
    }
}
