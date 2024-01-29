using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;

    [SerializeField] private float timeToAttack = 0.5f;
    private float timer = 0f;
    public Animator animator;
    [SerializeField] private AudioClip swordSound;
    public LayerMask enemyLayer;

    [SerializeField] private KeyCode attackKey = KeyCode.Space;

    private MovePlayer movePlayer;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        movePlayer = GetComponent<MovePlayer>(); // Get the reference to MovePlayer
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey) && !attacking)
        {
            Attack();
            animator.SetTrigger("attack");
            movePlayer.enabled = false;
            timer = 0;
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
            movePlayer.enabled = false; // Disable MovePlayer script to stop movement
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
