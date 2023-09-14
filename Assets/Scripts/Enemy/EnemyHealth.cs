using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth;  // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount

        // Check if the enemy has been defeated
        if (currentHealth <= 0)
        {
            Die(); // Call the function to handle the enemy's death
        }
    }

    // Function to handle the enemy's death
    void Die()
    {
        // Add any death-related logic here, e.g., play death animation, drop items, etc.
        // For now, we'll just destroy the enemy GameObject
        Destroy(gameObject);
    }
}
