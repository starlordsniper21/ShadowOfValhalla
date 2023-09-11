using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : EnemyScript
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    

    
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


}
