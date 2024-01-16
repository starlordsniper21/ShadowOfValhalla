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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage((int)damage);
        }
        Destroy(gameObject);
    }
}
