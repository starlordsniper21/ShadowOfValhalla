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

           
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.position = rb.position;

            timer = 0.5f; 
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
            movePlayer.enabled = false;

            // boss michael kung mababasa mo to, ito pala yung gagawin para mag stop yung player ahahaha
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.position = rb.position;
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
