using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWizard : MonoBehaviour
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
                animator.SetBool("BossWizardRunning", true);
                animator.SetBool("BossWizardAttacking", false);

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
                animator.SetBool("BossWizardRunning", false);
                animator.SetBool("BossWizardAttacking", true);

                // Instantiate and fire bullets
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
            else
            {
                animator.SetBool("BossWizardRunning", false);
                animator.SetBool("BossWizardAttacking", false);
            }
        }
        else
        {
            animator.SetBool("BossWizardRunning", false);
            animator.SetBool("BossWizardAttacking", false);
        }

        if (distanceFromPlayer > lineOfSight)
        {
            animator.SetBool("BossWizardIdle", true);
        }
        else
        {
            animator.SetBool("BossWizardIdle", false);
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
