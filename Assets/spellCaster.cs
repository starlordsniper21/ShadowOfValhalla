using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public Animator animator;
    [SerializeField] private float fireballSpeed = 10f;
    [SerializeField] private float cooldownTime = 0.5f;
    private Vector2 playerDirection = Vector2.right;
    private float cooldownTimer = 0f;
    private ManaSystem manaSystem;

    void Start()
    {
        animator = GetComponent<Animator>();
        manaSystem = GetComponent<ManaSystem>();
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire")) && cooldownTimer <= 0f)
        {
            ShootFireball();
            cooldownTimer = cooldownTime;
        }
        else if (cooldownTimer > 0f)
        {
            Debug.Log("Cooldown");
        }
    }

    void ShootFireball()
    {
        if (manaSystem.CanCastSpell())
        {
            manaSystem.UseMana(); // Use mana to cast the spell

            if (fireballPrefab != null && firePoint != null)
            {
                GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.velocity = playerDirection * fireballSpeed;

                    if (transform.localScale.x < 0)
                    {
                        Vector3 scale = fireball.transform.localScale;
                        scale.x *= -1;
                        fireball.transform.localScale = scale;
                    }
                }
                else
                {
                    Debug.LogWarning("Fireball prefab is missing Rigidbody2D component.");
                }
            }
            else
            {
                Debug.LogWarning("Fireball prefab or firePoint not assigned in the inspector.");
            }
        }
        else
        {
            Debug.Log("Not enough mana to shoot fireball.");
        }
    }

    public void SetPlayerDirection(Vector2 direction)
    {
        playerDirection = direction.normalized;
    }
}
