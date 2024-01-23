using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody;
    [SerializeField] private float damage;

    public void Setup(Vector2 playerDirection)
    {
        if (playerDirection == Vector2.zero)
        {
            playerDirection = Vector2.right;
        }

        Vector2 spellDirection = playerDirection;
        if (playerDirection.x < 0)
        {
            spellDirection = new Vector2(-spellDirection.x, spellDirection.y);
        }

        Vector2 velocity = spellDirection.normalized * speed;
        myRigidbody.velocity = velocity;

        float angle = Mathf.Atan2(spellDirection.y, spellDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage((int)damage);
        }

        Destroy(gameObject);
    }
}
