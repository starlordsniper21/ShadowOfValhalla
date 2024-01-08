using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;

    [SerializeField] private float timeToAttack = 0.5f;
    private float timer = 0f;
    public Animator animator;
    [SerializeField] private AudioClip swordSound;
    //public float knockbackForce = 10f;
    public LayerMask enemyLayer;
    private MovePlayer movePlayer; // Reference to the MovePlayer script

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        movePlayer = GetComponent<MovePlayer>(); // Get the reference to MovePlayer
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

                // After the attack animation is done, allow the player to move again
                movePlayer.EnableMovement(true);
            }
        }
    }

    public void MobileAttackButtonClicked()
    {
        if (!attacking)
        {
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlaySound(swordSound);
            }
            else
            {
                Debug.LogWarning("SoundManager is not properly initialized.");
            }

            // Initiate the attack and stop player movement
            Attack();
            animator.SetTrigger("attack");
            movePlayer.EnableMovement(false);   
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

   
}
