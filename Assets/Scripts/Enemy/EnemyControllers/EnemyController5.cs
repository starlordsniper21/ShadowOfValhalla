using UnityEngine;

public class EnemyController5: MonoBehaviour
{
    private QuestManager5 questManager5;
    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    private void Start()
    {
        questManager5 = FindObjectOfType<QuestManager5>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        questManager5.DefeatTheBats1();
        questManager5.DefeatBats2();
        questManager5.DefeatBats3();
        questManager5.DefeatEvilWarlock();

    }

    // Function to apply knockback to the enemy
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
