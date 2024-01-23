using System.Collections;
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

    public ManaSystem manaSystem;

    private bool isInvulnerable = false;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

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
        if (direction == Vector2.zero)
        {
            direction = isFacingRight ? Vector2.right : Vector2.left;
        }

        playerBow.SetPlayerDirection(direction);

        if (horizontalInput > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ReduceMana();
        }
    }

    private void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            HandleRegularMovement();
        }
        else
        {
            HandleKnockback();
        }
    }

    private void HandleRegularMovement()
    {
        rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
    }

    private void HandleKnockback()
    {
        if (KnockFromRight)
        {
            rb.velocity = new Vector2(-KBForce, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(KBForce, rb.velocity.y);
        }

        KBCounter -= Time.deltaTime;
    }

    public void ActivateInvulnerability(float duration)
    {
        StartCoroutine(InvulnerabilityCoroutine(duration));
    }

    private IEnumerator InvulnerabilityCoroutine(float duration)
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(duration);
        isInvulnerable = false;
    }

    void ReduceMana()
    {
        if (manaSystem != null)
        {
            manaSystem.UseMana();
        }
        else
        {
            Debug.LogWarning("ManaSystem is not assigned to the player.");
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
