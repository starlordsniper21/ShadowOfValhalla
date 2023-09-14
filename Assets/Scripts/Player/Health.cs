using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    //private Animator anim;
    private bool dead;
    private GameOverManager gameOverManager;
    

    private void Awake()
    {
        currentHealth = startingHealth;
        //anim = GetComponent<Animator>();
        gameOverManager = FindObjectOfType<GameOverManager>();    
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
          //hurt
          //anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                    //die
                    dead = true;
                    gameOverManager.gameOver();
                    print("dead");
                    //anim.SetTrigger("die");}
            }
           

        }
    }





}
