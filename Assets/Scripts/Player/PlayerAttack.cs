using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace for Button

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public Animator animator;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        // Check for mobile button click (you can replace "MobileAttackButton" with your button's name)
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    // This function will be called when the mobile attack button is clicked
    public void MobileAttackButtonClicked()
    {
        if (!attacking)
        {
            Attack();
            print("Attack");
            animator.SetTrigger("attack");
        }
    }

    public void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
