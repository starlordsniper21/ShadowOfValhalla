using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Animator animator;
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private PlayerBow playerBow;
    private bool canMove = true; // Added variable for controlling movement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerBow = GetComponent<PlayerBow>();
    }

    private void Update()
    {
        if (!canMove)
        {
            return; // Exit the function if movement is disabled
        }

        float horizontalInput = movementJoystick.joystickVec.x;
        float verticalInput = movementJoystick.joystickVec.y;

        animator.SetBool("movementright", horizontalInput > 0);
        animator.SetBool("movementleft", horizontalInput < 0);
        animator.SetBool("movementupanddown", verticalInput != 0);
        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        playerBow.SetPlayerDirection(direction);

        if (horizontalInput > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero; // Stop player's movement
            return;
        }

        if (movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void EnableMovement(bool enable)
    {
        canMove = enable;
    }
}
