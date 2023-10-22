using UnityEngine;

public class EnemyController3 : MonoBehaviour
{
    private QuestManager3 questManager3;
    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    private void Start()
    {
        questManager3 = FindObjectOfType<QuestManager3>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        questManager3.BatKilled();

        questManager3.EnemiesKilled();

        questManager3.GeneralKilled();


    }

    // Function to apply knockback to the enemy
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
