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
                // Moving towards the player
                animator.SetBool("BossRunning", true);
                animator.SetBool("BossIdle", false);

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
                // Firing at the player
                animator.SetBool("BossRunning", false);
                animator.SetBool("BossIdle", false);
                animator.SetTrigger("BossAttacking");

                // Instantiate and fire bullets
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            // Player out of range, going back to idle
            animator.SetBool("BossRunning", false);
            animator.SetBool("BossIdle", true);
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
