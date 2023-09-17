using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Animator animator;
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = movementJoystick.joystickVec.x;
        float verticalInput = movementJoystick.joystickVec.y;

        // Set animator boolean parameters based on joystick input
        animator.SetBool("movementright", horizontalInput > 0);
        animator.SetBool("movementleft", horizontalInput < 0);
        animator.SetBool("movementupanddown", verticalInput != 0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}