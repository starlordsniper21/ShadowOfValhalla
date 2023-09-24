using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private QuestManager questManager;
    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        // Call this when the enemy is defeated.
        questManager.EnemyKilled();
    }

    // Function to apply knockback to the enemy
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
