using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth = 20; 
    public float currentHealth { get; set; }
    private Animator anim;
    private bool dead;
    private GameOverManager gameOverManager;
    [SerializeField] private AudioClip deathSoundPlayer;
    [SerializeField] private AudioClip hurtSoundPlayer;
    [SerializeField] private float invulnerabilityDuration = 2.0f;
    private float invulnerabilityTimer = 0.0f;

    private Renderer renderer;
    private Collider2D collider;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        gameOverManager = FindObjectOfType<GameOverManager>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        if (invulnerabilityTimer <= 0)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                invulnerabilityTimer = invulnerabilityDuration;
                anim.SetTrigger("hurt");
                SoundManager.instance.PlaySound(hurtSoundPlayer);
            }
            else
            {
                if (!dead)
                {
                    dead = true;
                    SoundManager.instance.PlaySound(deathSoundPlayer);
                   
                    renderer.enabled = false;
                    collider.enabled = false;
                    gameOverManager.gameOver();
                    Debug.Log("dead");
                }
            }
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }


    public void RestoreHealth(float amount)
    {
        AddHealth(amount);
        Debug.Log("Health Restored: " + amount);
    }

    public void ActivateInvulnerability(float duration)
    {
        invulnerabilityTimer = duration;
        Debug.Log("Invulnerability activated!");
    }
}
