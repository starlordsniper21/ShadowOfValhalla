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
    private bool canMove = true;

    public ManaSystem manaSystem;

    private bool isInvulnerable = false;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerBow = GetComponent<PlayerBow>();
    }

    private void Update()
    {
        if (isAttacking)
            return;

        float horizontalInput = canMove ? movementJoystick.joystickVec.x : 0f;
        float verticalInput = canMove ? movementJoystick.joystickVec.y : 0f;

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

        if (Input.GetKeyDown(KeyCode.Q) && !isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        animator.SetTrigger("attack");
        canMove = false;
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        canMove = true;
    }

    private void FixedUpdate()
    {
        if (KBCounter <= 0 && canMove)
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
}
