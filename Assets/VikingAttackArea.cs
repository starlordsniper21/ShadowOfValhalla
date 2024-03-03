using UnityEngine;

public class VikingAttackArea : MonoBehaviour
{
    public float attackDamage = 10f; // Amount of damage the enemy's attack deals
    public float knockbackThrust = 10f; // Amount of thrust for knockback
    public Rigidbody2D playerRigidbody; // Reference to the Rigidbody2D of the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Damage the player
            Armor armorComponent = other.GetComponent<Armor>();
            if (armorComponent != null && armorComponent.currentArmor > 0)
            {
                armorComponent.TakeDamage(attackDamage);
                Debug.Log("Armor Damage: " + attackDamage);
            }
            else
            {
                Health healthComponent = other.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(attackDamage);
                    Debug.Log("Health Damage: " + attackDamage);
                    if (playerRigidbody != null)
                    {
                        Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                        playerRigidbody.velocity = Vector2.zero;
                        playerRigidbody.AddForce(knockbackDirection * knockbackThrust, ForceMode2D.Impulse);
                    }
                }
            }
            gameObject.SetActive(false);
        }
    }
}
