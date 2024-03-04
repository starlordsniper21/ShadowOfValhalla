using UnityEngine;
using System.Collections;

public class VikingEnemy : MonoBehaviour
{
    public float detectionRadius = 5f; 
    public float preparationRadius = 4f; 
    public float attackRadius = 2f;
    public float prepareTime = 5f;
    public float attackInterval = 5f;
    public float movementSpeed = 2f;
    public float disableRadius = 8f; 
    public Animator animator;
    public GameObject vikingAttackArea;
    private Transform player;
    private bool playerInRange = false;
    private bool preparing = false;
    private float prepareTimer = 0f;
    private float attackTimer = 0f;
    bool isVikingAttackAreaActive = false;
    float timeElapsedAfterPreparation = 0f;
    private bool facingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vikingAttackArea.SetActive(false);
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        animator.SetBool("VikingI", true);

        if (distanceToPlayer <= detectionRadius)
        {
            playerInRange = true;
            if (!preparing)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * movementSpeed * Time.deltaTime);

               // Flipping Logic nung enemy

                if (direction.x > 0 && !facingRight)
                {
                    Flip();
                }
                else if (direction.x < 0 && facingRight)
                {
                    Flip();
                }

                // run animation 
                animator.SetBool("IsRunning", true);
            }
            if (distanceToPlayer <= preparationRadius && !preparing)
            {
                // prepare attack animation
                animator.SetTrigger("VikingR");
                preparing = true;
                prepareTimer = 0f;
                Debug.Log("Enemy starts preparing for attack.");
            }

            if (preparing)
            {
                prepareTimer += Time.deltaTime;
                if (prepareTimer >= prepareTime)
                {
                    preparing = false;
                    Debug.Log("Preparation for attack complete.");

                    // Trigger attack animation
                    animator.SetTrigger("Attack");
                }
            }
            // ito pinalitan ko boss ginawa ko is mag aactivate lang ang attack area if playing ang attack animation
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("vikingAttack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
               
                vikingAttackArea.SetActive(true);
                isVikingAttackAreaActive = true;
            }
            else
            {
                // tas eto ididisable niya attack area after ng attck animation
                vikingAttackArea.SetActive(false);
                isVikingAttackAreaActive = false;
            }

            if (distanceToPlayer <= attackRadius)
            {
                // wala lang
            }
        }
        else
        {
            playerInRange = false;
            prepareTimer = 0f;
            attackTimer = 0f;
            preparing = false; 

          
            vikingAttackArea.SetActive(false);
            isVikingAttackAreaActive = false;

            
            animator.SetBool("IsRunning", false);
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
