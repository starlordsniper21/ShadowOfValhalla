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
    private BoxCollider2D boxCollider;
    private bool hit;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector2.Distance(target.position, transform.position) <= chaseRadius)
        {
            Vector2 moveDirection = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);


            // kung mabasa mo to michael nagawa ko na flip ng enemies
            // Flip the enemy based on movement direction
            if (moveDirection.x > 0)
                spriteRenderer.flipX = false; // Enemy faces right
            else if (moveDirection.x < 0)
                spriteRenderer.flipX = true; // Enemy faces left
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
