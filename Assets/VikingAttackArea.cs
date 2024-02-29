using UnityEngine;

public class VikingAttackArea : MonoBehaviour
{
    public float attackDamage = 10f; // Amount of damage the enemy's attack deals

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Damage the player
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }

            // Disable the attack area collider
            gameObject.SetActive(false);
        }
    }
}
