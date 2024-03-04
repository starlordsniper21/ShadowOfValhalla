using UnityEngine;
using System.Collections;

public class VikingEnemy : MonoBehaviour
{
    public float detectionRadius = 5f; // Radius to detect the player
    public float preparationRadius = 4f; // Radius for preparation before attack
    public float attackRadius = 2f;
    public float prepareTime = 5f;
    public float attackInterval = 5f;
    public float movementSpeed = 2f;
    public float disableRadius = 8f; // Radius to disable the attack area
    public Animator animator;
    public GameObject vikingAttackArea;
    private Transform player;
    private bool playerInRange = false;
    private bool preparing = false;
    private float prepareTimer = 0f;
    private float attackTimer = 0f;
    bool isVikingAttackAreaActive = false;
    float timeElapsedAfterPreparation = 0f;
    private bool facingRight = true; // Track the direction the Viking is facing

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vikingAttackArea.SetActive(false);
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            playerInRange = true;
            if (!preparing)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * movementSpeed * Time.deltaTime);

                // Flip the Viking if needed
                if (direction.x > 0 && !facingRight)
                {
                    Flip();
                }
                else if (direction.x < 0 && facingRight)
                {
                    Flip();
                }

                // Trigger running animation
                animator.SetBool("IsRunning", true);
            }
            if (distanceToPlayer <= preparationRadius && !preparing)
            {
                // Start preparing for attack
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

                    // Enable the attack area collider
                    vikingAttackArea.SetActive(true);
                    isVikingAttackAreaActive = true;
                    Attack();
                    StartCoroutine(DisableAttackAreaAfterDelay(2f));
                }
            }

            if (!preparing && isVikingAttackAreaActive && !vikingAttackArea.activeSelf)
            {
                // If the attack area is active but hasn't hit the player yet, start the delay
                if (distanceToPlayer <= disableRadius)
                {
                    StartCoroutine(DisableAttackAreaAfterDelay(1f));
                    vikingAttackArea.SetActive(false);
                }
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
            preparing = false; // Reset preparing flag when player is out of range

            // Disable the attack area collider when player is out of range
            vikingAttackArea.SetActive(false);
            isVikingAttackAreaActive = false;

            // Stop running animation when player is out of range
            animator.SetBool("IsRunning", false);
        }
    }

    IEnumerator DisableAttackAreaAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        vikingAttackArea.SetActive(false);
        isVikingAttackAreaActive = false;
    }

    private void Attack()
    {
        // Play attack animation
        animator.SetTrigger("VikingA");
        Debug.Log("Enemy attacks the player.");
        attackTimer = 0f;
    }

    private void Flip()
    {
        // Flip the Viking's scale to change direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw detection radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Draw preparation radius
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, preparationRadius);

        // Draw attack radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        // Draw disable radius
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, disableRadius);
    }
}
