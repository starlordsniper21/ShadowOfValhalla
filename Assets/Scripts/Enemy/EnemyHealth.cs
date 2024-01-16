using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth;  // Current health of the enemy
    [SerializeField] FloatingHealthBar healthBar;
    private Animator anim;
    [SerializeField] private AudioClip deathSoundEnemy;
    [SerializeField] private AudioClip hurtSoundEnemy;

    public GameObject[] itemPrefabs;
    public float dropChance = 0.2f;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

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

    public float GetCurrentHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }

    // Function to handle the enemy's death
    void Die()
    {
        if (Random.value <= dropChance)
        {
            SpawnItem();
        }
        Destroy(gameObject);
    }

    void SpawnItem()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
