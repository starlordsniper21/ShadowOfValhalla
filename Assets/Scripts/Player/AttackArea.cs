using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the script component of the player object
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();

            if (playerAttack != null)
            {
                playerAttack.Attack();
                Debug.Log("Player attack triggered");
            }
        }
    }
}
