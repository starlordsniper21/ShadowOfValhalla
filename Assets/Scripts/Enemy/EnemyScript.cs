using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    [SerializeField] private float damage;
    public float moveSpeed;
    private SpriteRenderer spriteRenderer;
    public MovePlayer movePlayer;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        if (target == null)
        {
            Debug.LogError("Player Script di nakalagay sa hirerachy ng enemies");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (target != null && Vector2.Distance(target.position, transform.position) <= chaseRadius)
        {
            Vector2 moveDirection = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Flip the enemy based on movement direction
            if (moveDirection.x > 0)
                spriteRenderer.flipX = false; // Enemy faces right
            else if (moveDirection.x < 0)
                spriteRenderer.flipX = true; // Enemy faces left
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && movePlayer != null)
        {
            movePlayer.KBCounter = movePlayer.KBTotalTime;

            if (collision.transform.position.x <= transform.position.x)
            {
                movePlayer.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                movePlayer.KnockFromRight = false;
            }

            Health healthComponent = collision.GetComponent<Health>();
            healthComponent?.TakeDamage(damage);
        }
    }
}
