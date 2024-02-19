using UnityEngine;

public class EnemyController7: MonoBehaviour
{
    private QuestManager7 questManager7;
    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    private void Start()
    {
        questManager7 = FindObjectOfType<QuestManager7>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        questManager7.DefeatEastSideGeneral();
        questManager7.DefeatWestSideGeneral();
        questManager7.DefeatTwinGeneral(); 


    }

    // Function to apply knockback to the enemy
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
