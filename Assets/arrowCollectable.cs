using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowCollectable : MonoBehaviour
{
    [SerializeField] private int arrowValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerBow>().CollectArrows(arrowValue);
            gameObject.SetActive(false);
        }
    }


}
