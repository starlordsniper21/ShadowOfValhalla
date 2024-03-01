using UnityEngine;

public class VikingEnemy : MonoBehaviour
{
    public float detectionRadius = 5f; // Radius to detect the player
    public float preparationRadius = 4f; // Radius for preparation before attack
    public float attackRadius = 2f; // Radius to attack the player
    public float prepareTime = 5f; // Time to prepare for attack
    public float attackInterval = 5f; // Time between attacks
    public float movementSpeed = 2f; // Movement speed
    public Animator animator; // Reference to the animator component
    public GameObject vikingAttackArea; // Reference to the attack area GameObject
    private Transform player; // Reference to the player's transform
    private bool playerInRange = false; // Flag to track if player is in range
    private bool preparing = false; // Flag to track if enemy is preparing
    private float prepareTimer = 0f; // Timer for preparing attack
    private float attackTimer = 0f; // Timer for attack interval
   

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vikingAttackArea.SetActive(false); // Initially disable the attack area
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if player is within detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            playerInRange = true;

            // Move towards player only if not preparing
            if (!preparing)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * movementSpeed * Time.deltaTime);
            }

            // Check if player is within preparation radius
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
                // Increment prepare timer
                prepareTimer += Time.deltaTime;

                // Check if preparation time is complete
                if (prepareTimer >= prepareTime)
                {
                    // Preparation time finished
                    preparing = false;
                    Debug.Log("Preparation for attack complete.");

                    // Enable the attack area collider
                    vikingAttackArea.SetActive(true);

                    // Initiate the attack
                    Attack();
                }
            }

            // Check if player is within attack radius
            if (distanceToPlayer <= attackRadius)
            {
                // No need to attack here since the attack is initiated after preparation
            }
        }
        else
        {
            playerInRange = false;
            // Reset timers if player is not in range
            prepareTimer = 0f;
            attackTimer = 0f;
            preparing = false; // Reset preparing flag when player is out of range

            // Disable the attack area collider when player is out of range
            vikingAttackArea.SetActive(false);
        }
    }

    private void Attack()
    {
        // Play attack animation
        animator.SetTrigger("VikingA");

        // Perform damage to the player
        // Implement the logic to damage the player here
        Debug.Log("Enemy attacks the player.");

        // Set attack timer for attack interval
        attackTimer = 0f;
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
    }
}
