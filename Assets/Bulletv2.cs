using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletv2 : MonoBehaviour
{
    public float bulletLife = 1f;  // Defines how long before the bullet is destroyed
    public float rotation = 0f;
    public float speed = 1f;
    public int damage = 1;

    private Vector2 spawnPoint;
    private float timer = 0f;

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (timer > bulletLife)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            Armor playerArmor = other.GetComponent<Armor>(); // Get the player's armor component
            if (playerHealth != null)
            {
                if (playerArmor != null)
                {
                    // Reduce armor first
                    playerArmor.TakeDamage(damage);

                    // If armor is completely depleted, apply remaining damage to health
                    if (playerArmor.currentArmor <= 0)
                    {
                        playerHealth.TakeDamage(damage);
                    }
                }
                else
                {
                    // Player doesn't have armor, apply damage directly to health
                    playerHealth.TakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
