using UnityEngine;

public class EnemyAIRanged : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private bool facingRight = true;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSight)
        {
            if (distanceFromPlayer > shootingRange)
            {
                animator.SetBool("BossRunning", true);
                animator.SetBool("BossAttacking", false);

                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Flip the enemy if needed
                if (player.position.x > transform.position.x && !facingRight)
                {
                    Flip();
                }
                else if (player.position.x < transform.position.x && facingRight)
                {
                    Flip();
                }
            }
            else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
            {
                animator.SetBool("BossRunning", false);
                animator.SetBool("BossAttacking", true);

                // Instantiate and fire bullets
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
            else
            {
                animator.SetBool("BossRunning", false);
                animator.SetBool("BossAttacking", false);
            }
        }
        else
        {
            animator.SetBool("BossRunning", false);
            animator.SetBool("BossAttacking", false);
        }

        if (distanceFromPlayer > lineOfSight)
        {
            animator.SetBool("BossIdle", true);
        }
        else
        {
            animator.SetBool("BossIdle", false);
        }
    }

    private void Flip()
    {
        // Flip the enemy's scale to change direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
