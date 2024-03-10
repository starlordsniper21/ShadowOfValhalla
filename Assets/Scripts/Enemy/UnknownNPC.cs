using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownNPC : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float preparationRadius = 4f;
    public float attackRadius = 2f;
    public float prepareTime = 5f;
    public float attackInterval = 5f;
    public float movementSpeed = 2f;
    public float disableRadius = 8f;
    public Animator animator;
    public GameObject NpcAttackArea;
    private Transform Enemy;
    private bool enemyInRange = false;
    private bool preparing = false;
    private float prepareTimer = 0f;
    private float attackTimer = 0f;
    bool isVikingAttackAreaActive = false;
    float timeElapsedAfterPreparation = 0f;
    private bool facingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        NpcAttackArea.SetActive(false);
    }

    private void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy = collider.transform;
                enemyInRange = true;
                break;
            }
        }

        if (Enemy != null)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, Enemy.position);

            animator.SetBool("NpcI", true);

            if (distanceToEnemy <= detectionRadius)
            {
                if (!preparing)
                {
                    Vector2 direction = (Enemy.position - transform.position).normalized;
                    transform.Translate(direction * movementSpeed * Time.deltaTime);

                    if (direction.x > 0 && !facingRight)
                    {
                        Flip();
                    }
                    else if (direction.x < 0 && facingRight)
                    {
                        Flip();
                    }

                    animator.SetBool("IsRunningNpc", true);
                }
                if (distanceToEnemy <= preparationRadius && !preparing)
                {
                    preparing = true;
                    prepareTimer = 0f;
                }

                if (preparing)
                {
                    prepareTimer += Time.deltaTime;
                    if (prepareTimer >= prepareTime)
                    {
                        preparing = false;
                        animator.SetTrigger("Attack");
                    }
                }
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("NpcAttacking") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
                {

                    NpcAttackArea.SetActive(true);
                    isVikingAttackAreaActive = true;
                }
                else
                {
                    NpcAttackArea.SetActive(false);
                    isVikingAttackAreaActive = false;
                }

                if (distanceToEnemy <= attackRadius)
                {
                    // wala lang
                }
            }
            else
            {
                enemyInRange = false;
                prepareTimer = 0f;
                attackTimer = 0f;
                preparing = false;

                NpcAttackArea.SetActive(false);
                isVikingAttackAreaActive = false;

                animator.SetBool("IsRunningNpc", false);
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, preparationRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, disableRadius);
    }
}
