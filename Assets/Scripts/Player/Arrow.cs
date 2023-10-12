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
        Vector2 velocity = playerDirection.normalized * speed;
        myRigidbody.velocity = velocity;

        // Determine the rotation angle based on the direction
        float angle = Vector2.SignedAngle(Vector2.right, playerDirection);
        transform.rotation = Quaternion.Euler(0, 0, angle);
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
