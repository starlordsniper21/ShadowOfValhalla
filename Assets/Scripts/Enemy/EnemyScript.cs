using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    [SerializeField]private float damage;
    public float moveSpeed;
    private BoxCollider2D boxCollider;
    private bool hit;



    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector2.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

   

}
