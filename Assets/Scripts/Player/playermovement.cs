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
    private PlayerFireball playerFireball;
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
        playerFireball = GetComponent<PlayerFireball>();
    }

    private void Update()
    {
        if (isAttacking)
            return;
        // new UPDATED MOVEMENT SA JOYSTICK BOSS!!!
        float horizontalInput = canMove ? movementJoystick.joystickVec.x : 0f;
        float verticalInput = canMove ? movementJoystick.joystickVec.y : 0f;

        animator.SetBool("movementright", horizontalInput > 0);
        animator.SetBool("movementleft", horizontalInput < 0);
        animator.SetBool("movementupanddown", verticalInput > 0);

        animator.SetFloat("Horizontal",movementJoystick.joystickVec.x);
        animator.SetFloat("Vertical", movementJoystick.joystickVec.y);
        animator.SetFloat("speed", movementJoystick.joystickVec.sqrMagnitude);



        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        if (direction == Vector2.zero)
        {
            direction = isFacingRight ? Vector2.right : Vector2.left;
        }

        
        if (playerBow != null)
        {
            playerBow.SetPlayerDirection(direction);
        }
        if (playerFireball != null)
        {
            playerFireball.SetPlayerDirection(direction);
        }

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

     
        Vector2 initialPosition = rb.position;

        
        yield return new WaitForSeconds(0.5f);


        rb.velocity = Vector2.zero;
        rb.position = initialPosition;

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
