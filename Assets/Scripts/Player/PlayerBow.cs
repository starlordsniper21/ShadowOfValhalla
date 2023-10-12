using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public Animator animator;
    [SerializeField] private float arrowSpeed = 10f;
    private Vector2 playerDirection = Vector2.right;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Bow"))
        {
            FireArrow();
        }
    }

    public void MobileAttackButtonClicked()
    {
        FireArrow();
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
                Debug.LogWarning("lmao walang rigidbody2d ang arrow");
            }
        }
        else
        {
            Debug.LogWarning("Arrow prefab or firePoint not assigned in the inspector.");
        }
    }

    public void SetPlayerDirection(Vector2 direction)
    {
        playerDirection = direction;
    }
}
