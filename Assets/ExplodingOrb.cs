using UnityEngine;

public class TimerBox : MonoBehaviour
{
    public float duration = 5f; // Duration of the timer in seconds
    public float explosionRadius = 5f; // Radius of explosion
    public int damageAmount = 50;
    public Color explosionColor = Color.red;
    public Animator animator;
    public AudioSource explosionSound;

    private bool triggered = false;

    void Start()
    {
        Invoke("TriggerBehavior", duration); // Start the timer
        animator.SetBool("Idle", true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = explosionColor;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void TriggerBehavior()
    {
        if (!triggered)
        {
            triggered = true;
            animator.SetBool("Idle", false);
            animator.SetBool("Explode", true);
            if (explosionSound != null)
            {
                explosionSound.Play();
            }

            // Damage objects in the explosion radius
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    // Damage the player
                    Armor armorComponent = collider.GetComponent<Armor>();
                    if (armorComponent != null && armorComponent.currentArmor > 0)
                    {
                        armorComponent.TakeDamage(damageAmount);
                        Debug.Log("Armor Damage: " + damageAmount);
                    }
                    else
                    {
                        Health healthComponent = collider.GetComponent<Health>();
                        if (healthComponent != null)
                        {
                            healthComponent.TakeDamage(damageAmount);
                            Debug.Log("Health Damage: " + damageAmount);
                        }
                    }
                }
                else if (collider.CompareTag("Enemy"))
                {
                    // Damage the enemy
                    EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damageAmount);
                        Debug.Log("Enemy Damage: " + damageAmount);
                    }
                }
            }
            Destroy(gameObject, 1f); // Delay destruction by 1 second to allow animation to finish
        }
    }
}
