using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    public int damage = 2;
    public int armorDamage = 1; 
    Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            Armor playerArmor = other.GetComponent<Armor>(); 
            if (playerHealth != null)
            {
                if (playerArmor != null)
                {
                    
                    playerArmor.TakeDamage(armorDamage);

                    
                    if (playerArmor.currentArmor <= 0)
                    {
                        playerHealth.TakeDamage(damage);
                    }
                }
                else
                {
                    
                    playerHealth.TakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
    }

}

