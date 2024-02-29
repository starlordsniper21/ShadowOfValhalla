using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    public int damageAmount = 2; // Adjust this as per your game's balance

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the object has a Health script
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                // Call the TakeDamage method of the player's Health script
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
