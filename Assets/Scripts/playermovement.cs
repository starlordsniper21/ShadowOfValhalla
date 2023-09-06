using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator animator;
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        

        animator.SetFloat("Horizontal", movementJoystick.joystickVec.x);
        animator.SetFloat("Vertical", movementJoystick.joystickVec.y);
        animator.SetFloat("Speed", movementJoystick.joystickVec.sqrMagnitude);



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