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
    [SerializeField] private AudioClip deathSoundPlayer;
    [SerializeField] private AudioClip hurtSoundPlayer;
    [SerializeField] private float invulnerabilityDuration = 2.0f;
    private float invulnerabilityTimer = 0.0f;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>(); 
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    private void Update()
    {
      
        if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;

         
        }
    }

    public void TakeDamage(float _damage)
    {
        
        if (invulnerabilityTimer <= 0)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

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
                    gameOverManager.gameOver();
                    print("dead");
                    
                }
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }


}
