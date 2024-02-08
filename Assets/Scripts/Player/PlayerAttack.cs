using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private bool cooldown = false;

    [SerializeField] private float timeToAttack = 0.5f;
    private float timer = 0f;
    public Animator animator;
    [SerializeField] private AudioClip swordSound;
    public LayerMask enemyLayer;

    [SerializeField] private KeyCode attackKey = KeyCode.Space;

    private MovePlayer movePlayer;

    [SerializeField] private float baseDamage = 10f;
    [SerializeField] private float damageModifier = 1f;
    [SerializeField] private float attackCooldown = 0.5f;
    private float cooldownTimer = 0f;

    private bool hasDoubleDamage = false;

    private float damageMultiplier = 1f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        movePlayer = GetComponent<MovePlayer>();
    }

    void Update()
    {
        if (!cooldown && Input.GetKeyDown(attackKey) && !attacking)
        {
            Attack();
            animator.SetTrigger("attack");
            movePlayer.enabled = false;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.position = rb.position;

            timer = 0.5f;
            cooldown = true;
            cooldownTimer = attackCooldown;
        }

        if (cooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                cooldown = false;
            }
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                movePlayer.enabled = true;
            }
        }
    }

    public void MobileAttackButtonClicked()
    {
        if (!cooldown && !attacking)
        {
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlaySound(swordSound);
            }
            else
            {
                Debug.LogWarning("SoundManager is not properly initialized.");
            }


            Attack();
            animator.SetTrigger("attack");
            movePlayer.enabled = false;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.position = rb.position;

            cooldown = true;
            cooldownTimer = attackCooldown;
        }
    }

    public void Attack()
    {
        float totalDamage = CalculateTotalDamage();
        attacking = true;
        attackArea.SetActive(attacking);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attacking)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    float totalDamage = baseDamage * damageModifier;
                    int damage = Mathf.RoundToInt(totalDamage);
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }

    public void ApplyDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
        Debug.Log("Player picked up damage multiplier power-up with multiplier: " + multiplier);
    }

    public void ResetDamageMultiplier()
    {
        damageMultiplier = 1f;
        Debug.Log("Damage multiplier power-up effect ended");
    }

    private float CalculateTotalDamage()
    {
        float totalDamage = baseDamage * damageModifier;
        totalDamage *= damageMultiplier;
        return totalDamage;
    }

}
