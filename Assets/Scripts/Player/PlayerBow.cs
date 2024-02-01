using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public Animator animator;
    [SerializeField] private float arrowSpeed = 10f;
    [SerializeField] private float cooldownTime = 0.5f;
    [SerializeField] private int maxArrows = 10;
    private Vector2 playerDirection = Vector2.right;
    private int remainingArrows;
    private float cooldownTimer = 0f;
    private int collectedArrows = 0;

    public TextMeshProUGUI arrowsText; // Reference to the TextMeshPro Text element

    void Awake()
    {
        animator = GetComponent<Animator>();
        remainingArrows = maxArrows;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Bow")) && remainingArrows > 0 && cooldownTimer <= 0f)
        {
            FireArrow();
            remainingArrows--;
            cooldownTimer = cooldownTime;
        }

        // Update the TextMeshPro text with the remaining arrows
        arrowsText.text =  remainingArrows.ToString();

        // For testing purposes, simulate arrow collection by pressing a key
        if (Input.GetKeyDown(KeyCode.C))
        {
            CollectArrows(3);
        }
    }

    public void MobileAttackButtonClicked()
    {
        if (remainingArrows > 0 && cooldownTimer <= 0f)
        {
            FireArrow();
            remainingArrows--;
            cooldownTimer = cooldownTime;
        }
        animator.SetTrigger("bow");
    }

    void FireArrow()
    {
        if (arrowPrefab != null && firePoint != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = playerDirection * arrowSpeed;

                if (playerDirection == Vector2.left)
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else
            {
                Debug.LogWarning("Arrow prefab is missing Rigidbody2D component.");
            }

            // Pass the player's direction to the arrow
            Arrow arrowScript = arrow.GetComponent<Arrow>();
            if (arrowScript != null)
            {
                arrowScript.Setup(playerDirection);
            }
        }
        else
        {
            Debug.LogWarning("Arrow prefab or firePoint not assigned in the inspector.");
        }
    }

    public void SetPlayerDirection(Vector2 direction)
    {
        playerDirection = direction.normalized;
    }

    public void CollectArrows(int amount)
    {
        collectedArrows += amount;
        Debug.Log("Collected " + amount + " arrows. Total arrows: " + collectedArrows);

        if (collectedArrows > maxArrows)
        {
            collectedArrows = maxArrows;
        }
        remainingArrows += amount;
    }
}
