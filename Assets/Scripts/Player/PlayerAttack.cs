using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;

    [SerializeField] private float timeToAttack = 0.5f; // Serialized field
    private float timer = 0f;
    public Animator animator;

    public float knockbackForce = 10f; // Serialized field
    public LayerMask enemyLayer; // Serialized field

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    public void MobileAttackButtonClicked()
    {
        if (!attacking)
        {
            Attack();
            animator.SetTrigger("attack");
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (attacking && enemyLayer == (enemyLayer | (1 << collision.gameObject.layer)))
        {
            // Enemy is hit; apply knockback
            Vector2 direction = collision.contacts[0].point - (Vector2)transform.position;
            collision.gameObject.GetComponent<EnemyController>().Knockback(direction * knockbackForce);
        }
    }
}
