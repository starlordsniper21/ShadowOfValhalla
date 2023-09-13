using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0)
        {
            Die(); // Player has no health left, handle player death here
        }
    }

    private void Die()
    {
        // Implement what should happen when the player dies, e.g., game over or respawn.
        // For example, you can disable the player object, show a game over screen, or trigger a respawn function.
        // You might want to create a GameManager script to manage such things.
        gameObject.SetActive(false); // Disable the player object in this example.
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Enemy" (you can set this tag in Unity's Inspector).
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Assuming you want to deal 1 damage when colliding with an enemy. 
            // You can adjust the damage amount as needed.
            TakeDamage(1);
        }
    }
}
