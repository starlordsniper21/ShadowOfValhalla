using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] FloatingHealthBar healthBar;
    private Animator anim;
    [SerializeField] private AudioClip deathSoundEnemy;
    [SerializeField] private AudioClip hurtSoundEnemy;

    public GameObject[] itemPrefabs;
    private bool hasDroppedItem = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(hurtSoundEnemy);
        }

        // Check if the enemy has been defeated
        if (currentHealth <= 0)
        {
            Die(); //death sound 
            SoundManager.instance.PlaySound(deathSoundEnemy);
        }
    }

    public float GetCurrentHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }

    // enemy dead
    void Die()
    {
        if (!hasDroppedItem && itemPrefabs.Length > 0)
        {
            // Spawn one random item
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
            hasDroppedItem = true; //Added boolean flag para di maginstance spawning ng prefabs
        }

        // Destroy the enemy
        Destroy(gameObject);
    }
}
