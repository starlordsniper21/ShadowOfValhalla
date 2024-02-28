using UnityEngine;

public class EnemyController1boss: MonoBehaviour
{
    private QuestManager1boss questManager1boss;
    private Rigidbody2D rb;

    //public float knockbackForce = 10f;

    private void Start()
    {
        questManager1boss = FindObjectOfType<QuestManager1boss>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        
        questManager1boss.DefeatCanute();
   
    }



   

    // Function to apply knockback to the enemy
    //public void Knockback(Vector2 direction)
    //{
    //    rb.velocity = Vector2.zero; 
    //    rb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
    //}
}
