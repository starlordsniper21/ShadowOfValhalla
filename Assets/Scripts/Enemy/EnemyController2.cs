using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    private QuestManager2 questManager2;
    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    private void Start()
    {
        questManager2 = FindObjectOfType<QuestManager2>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        // Call this when the enemy is defeated.
        questManager2.GuardDefeated(); // Increment Guard Defeated quest
        questManager2.EnemyDefeated(); // Increment Enemy Defeated quest
        questManager2.DungeonGuardsDefeated();
    }

    // Function to apply knockback to the enemy
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
