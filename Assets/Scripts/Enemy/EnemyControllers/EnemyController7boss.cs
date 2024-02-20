using UnityEngine;

public class EnemyController7boss: MonoBehaviour
{
    private QuestManager7boss questManager7boss;
    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    private void Start()
    {
        questManager7boss = FindObjectOfType<QuestManager7boss>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        questManager7boss.DefeatCanute();


    }

    // Function to apply knockback to the enemy
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
