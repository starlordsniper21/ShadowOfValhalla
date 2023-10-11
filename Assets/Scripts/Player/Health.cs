using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private GameOverManager gameOverManager;
    [SerializeField]private AudioClip deathSoundPlayer;
    [SerializeField]private AudioClip hurtSoundPlayer;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        gameOverManager = FindObjectOfType<GameOverManager>();    
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
          anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(hurtSoundPlayer);
        }
        else
        {
            if (!dead)
            {
                    //die
                    dead = true;
                    SoundManager.instance.PlaySound(deathSoundPlayer);
                    gameOverManager.gameOver();
                    print("dead");
                    
                    //anim.SetTrigger("die");}
            }
           

        }
    }





}
