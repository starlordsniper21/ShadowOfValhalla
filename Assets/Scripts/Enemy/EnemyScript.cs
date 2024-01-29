using UnityEngine;

public class Jester : MonoBehaviour
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    [SerializeField] private float armorDamage;
    [SerializeField] private float healthDamage;
    public float moveSpeed;
    private SpriteRenderer spriteRenderer;
    public MovePlayer movePlayer;

    private float totalArmorDamage = 0f;
    private float totalHealthDamage = 0f;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        if (target == null)
        {
            Debug.LogError("Player Script di nakalagay sa hirerachy ng enemies");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (target != null && Vector2.Distance(target.position, transform.position) <= chaseRadius)
        {
            Vector2 moveDirection = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Flip the enemy based on movement direction
            if (moveDirection.x > 0)
                spriteRenderer.flipX = false; // Enemy faces right
            else if (moveDirection.x < 0)
                spriteRenderer.flipX = true; // Enemy faces left
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && movePlayer != null)
        {
            movePlayer.KBCounter = movePlayer.KBTotalTime;

            if (collision.transform.position.x <= transform.position.x)
                movePlayer.KnockFromRight = true;
            else
                movePlayer.KnockFromRight = false;

            Armor armorComponent = collision.GetComponent<Armor>();

            if (armorComponent != null && armorComponent.currentArmor > 0)
            {
                armorComponent.TakeDamage(armorDamage);
                totalArmorDamage += armorDamage;
                Debug.Log("Total Armor Damage: " + totalArmorDamage);
            }
            else
            {
                Health healthComponent = collision.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(healthDamage);
                    totalHealthDamage += healthDamage;
                    Debug.Log("Total Health Damage: " + totalHealthDamage);
                }
            }
        }
    }
}
