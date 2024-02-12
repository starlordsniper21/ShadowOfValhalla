using UnityEngine;

public class EnemyController6: MonoBehaviour
{
    private QuestManager6 questManager6;
    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    private void Start()
    {
        questManager6 = FindObjectOfType<QuestManager6>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        questManager6.KillTheGuards();
        questManager6.DefeatEnemyWarlock();


    }

    // Function to apply knockback to the enemy
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
