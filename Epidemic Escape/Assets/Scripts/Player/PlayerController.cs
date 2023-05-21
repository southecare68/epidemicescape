using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private MouseUtilities mouseUtilities;

    private Vector2 moveInput;

    private void Update()
    {
        Vector2 mouseDirection = mouseUtilities.GetMouseDirection(transform.position);

        spriteRenderer.flipX = mouseDirection.x < 0;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = moveInput * moveSpeed;
        rig.velocity = velocity;
    }

    public void OnMoveInput (InputAction.CallbackContext context)
    {
        System.Console.WriteLine("moving");
        moveInput = context.ReadValue<Vector2>();
    }
}
