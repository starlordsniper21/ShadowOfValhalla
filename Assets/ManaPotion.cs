using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public int manaRestoreAmount = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ManaSystem manaSystem = other.GetComponent<ManaSystem>();
            if (manaSystem != null)
            {
                manaSystem.RestoreMana(manaRestoreAmount);
                Destroy(gameObject);
            }
        }
    }
    


}
