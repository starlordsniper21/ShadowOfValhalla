using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody;
    [SerializeField] private float damage;

    // Modify the Setup method
    public void Setup(Vector2 playerDirection)
    {
        if (playerDirection == Vector2.zero)
        {
            playerDirection = Vector2.right;
        }

        Vector2 velocity = playerDirection.normalized * speed;
        myRigidbody.velocity = velocity;

        transform.right = playerDirection.normalized;
    }

    // Change to OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Check if collided with an enemy
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage((int)damage);

                Rigidbody2D enemyRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
                if (enemyRigidbody != null)
                {
                    enemyRigidbody.velocity = Vector2.zero;
                    enemyRigidbody.angularVelocity = 0f;
                    enemyRigidbody.gravityScale = 0f;
                }
            }

            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) // Check if not collided with a player
        {
            // Destroy the arrow if it collides with anything except the Player
            Destroy(gameObject);
        }
    }
}
