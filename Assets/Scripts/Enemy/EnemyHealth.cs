using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth;  // Current health of the enemy
    private Animator anim;
    [SerializeField]private AudioClip deathSoundEnemy;
    [SerializeField] private AudioClip hurtSoundEnemy;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(hurtSoundEnemy);
        }
        // Check if the enemy has been defeated
        if (currentHealth <= 0)
        {
            Die(); // Call the function to handle the enemy's death
            SoundManager.instance.PlaySound(deathSoundEnemy);
        }
    }

    // Function to handle the enemy's death
    void Die()
    {
        // Add any death-related logic here, e.g., play death animation, drop items, etc.
        Destroy(gameObject);
    }
}
